namespace Creating.From.Context.Entities
{
    using System;
    using System.Collections.Generic;

    public class Author : Core.EntityCore<Guid>
    {
        public string Name { get; set; }

        public IEnumerable<Book> Books { get; set; } = new List<Book>();
    }
}