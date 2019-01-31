namespace Creating.From.ConsoleApp.Entities
{
    using System;

    public class Book
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid AuthorId { get; set; }
        public Author Author { get; set; }
    }
}