namespace Creating.From.ConsoleApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contexts;
    using Creating.From.ConsoleApp.Entities;
    using Microsoft.EntityFrameworkCore;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var context = new LibraryContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            //context.Database.Migrate();

            Console.WriteLine();

            var author = context.Set<Author>()
                .Include(x => x.Books)
                .FirstOrDefault();

            Console.WriteLine($"Author - First: {author.Name}; Books: {string.Join(",", author.Books.Select(b => b.Name))}");

            Console.WriteLine();
            Console.WriteLine($"Author - List");
            var authors = context.Set<Author>().ToList();
            authors.ForEach(a => Console.WriteLine(a.Name));

            Console.WriteLine();
            Console.WriteLine("Press enter to exit");
            var h = Console.ReadLine();
            context.Dispose();
        }
    }
}
