using Microsoft.EntityFrameworkCore;

namespace Coursework2.Shared
{
    // Manages connection to the database
    public class ChinookDb : DbContext
    {
        // Mapping properties to tables in the DB

        // <Album> is the TYPE of the Albums database that we extract
        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }



        public ChinookDb(DbContextOptions<ChinookDb> options) : base(options) { }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder
        )
        {
            string path = System.IO.Path.Combine(System.Environment.CurrentDirectory, "../Chinook.db");
            optionsBuilder.UseSqlite($"Filename={path}");
        }
    }
}