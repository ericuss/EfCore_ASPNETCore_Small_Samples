namespace Creating.From.Context.Contexts
{
    using Microsoft.EntityFrameworkCore;

    public class LibraryContext : Context
    {
        // public DbSet<Author> Authors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseInMemoryDatabase("LibraryDb");
            optionsBuilder.UseSqlServer(@"Server=.;Initial Catalog=LibraryDb;Persist Security Info=False;User ID=sa;Password=Plain2018;MultipleActiveResultSets=False;Encrypt=false;TrustServerCertificate=False;Connection Timeout=30;");
        }   

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // var author = modelBuilder.Entity<Author>();
            // author.HasKey(x => x.Id);
            // author.HasMany(x => x.Books).WithOne(x => x.Author).HasForeignKey(x => x.AuthorId);
            // author.ToTable("Authors");

            // var book = modelBuilder.Entity<Book>();
            // book.HasKey(x => x.Id);
            // book.ToTable("Books");
        }
    }
}