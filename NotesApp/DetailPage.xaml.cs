using NotesApp.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace NotesApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DetailPage : Page
    {
        public DetailPage()
        {
            this.InitializeComponent();
        }
        Note Note;
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            Guid selectedItemId = (Guid)e.Parameter;
            using (var db = new NotesContext())
            {
                Note = db.Notes.Where(n => n.Id.Equals(selectedItemId)).First();
            }
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack(new DrillInNavigationTransitionInfo());
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new NotesContext())
            {
                db.Remove(Note);
                db.SaveChanges();
            }
            Frame.GoBack(new DrillInNavigationTransitionInfo());
        }
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(EditNotePage), Note.Id,
                             new DrillInNavigationTransitionInfo());

        }
    }
}
