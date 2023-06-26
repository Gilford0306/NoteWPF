using Microsoft.EntityFrameworkCore;
using NoteWPF.Model;

namespace NoteWPF.ViewModel
{
    public class MyApplicationContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-N6GODSK;Database=NoteDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}