namespace Creating.From.Api.Models
{
    using System;
    using System.Collections.Generic;

    public class AuthorWithBooksDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<string> Books { get; set; }
    }
}