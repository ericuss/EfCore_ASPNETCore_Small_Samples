namespace Creating.From.Context.Entities
{
    using System;

    public class Book : Core.EntityCore<Guid>
    {
        public string Name { get; set; }
        public Guid AuthorId { get; set; }
        public Author Author { get; set; }
    }
}