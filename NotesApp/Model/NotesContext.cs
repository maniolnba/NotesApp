using Microsoft.Data.Entity;
using System;
using System.IO;
using Windows.Storage;

namespace NotesApp.Model
{
    class NotesContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string databaseFilePath = "notes.db";
            try
            {
                databaseFilePath = Path.Combine(
                                ApplicationData.Current.LocalFolder.Path,
databaseFilePath);
            }
            catch (InvalidOperationException) { }
            optionsBuilder.UseSqlite($"Data source={databaseFilePath}");
        }
    }
}