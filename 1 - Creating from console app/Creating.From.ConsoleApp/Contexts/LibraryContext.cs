namespace Creating.From.ConsoleApp.Contexts
{
    using Creating.From.ConsoleApp.Entities;
    using Microsoft.EntityFrameworkCore;

    public class LibraryContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("LibraryDb");
        }
    }
}