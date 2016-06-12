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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace NotesApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        private void LoadNotes()
        {
            using (var db = new NotesContext())
            {
                NotesListView.ItemsSource = from n in db.Notes
                                            orderby n.DateModified
                                            descending select n;
            }
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            LoadNotes();
        }
        private void NewNote_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(EditNotePage), null);
        }
        private void MasterListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var selectedItem = e.ClickedItem as Note;
            Frame.Navigate(typeof(DetailPage), selectedItem.Id,
                            new DrillInNavigationTransitionInfo());
        }
        private void Date_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new NotesContext())
            {
                NotesListView.ItemsSource = from n in db.Notes
                                            orderby n.DateModified
                                            descending
                                            select n;
            }
            
        }
        private void Title_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new NotesContext())
            {
                NotesListView.ItemsSource = from n in db.Notes
                                            orderby n.Title
                                            ascending
                                            select n;
            }
            
        }
    }
}
