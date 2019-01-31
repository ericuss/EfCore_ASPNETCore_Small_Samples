namespace Creating.From.ConsoleApp
{
    using System;
    using System.Linq;
    using Contexts;
    using Creating.From.ConsoleApp.Entities;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var context = new LibraryContext();
            context.Add(new Author() { Id = Guid.NewGuid(), Name = "Santiago Posteguillo" });
            context.Add(new Author() { Id = Guid.NewGuid(), Name = "Simon Scarrow" });
            context.Add(new Author() { Id = Guid.NewGuid(), Name = "Steven Pressfiel" });
            context.Add(new Author() { Id = Guid.NewGuid(), Name = "Orson Scott" });
            context.Add(new Author() { Id = Guid.NewGuid(), Name = "John Scalzi" });
            context.SaveChanges();

            Console.WriteLine();
            var author = context.Set<Author>().FirstOrDefault();
            Console.WriteLine($"Author - First: {author.Name}");

            Console.WriteLine();
            Console.WriteLine($"Author - List");
            var authors = context.Set<Author>().ToList();
            authors.ForEach(a => Console.WriteLine(a.Name));

            Console.WriteLine();
            Console.WriteLine("Press any key to exit");
            var h = Console.ReadLine();
            context.Dispose();
        }
    }
}
