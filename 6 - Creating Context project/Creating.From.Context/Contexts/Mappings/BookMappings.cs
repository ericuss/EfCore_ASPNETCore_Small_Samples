namespace Creating.From.Context.Contexts.Mappings
{
    using System;
    using System.Collections.Generic;
    using Core;
    using Creating.From.Context.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BookMappings : MappingsConfiguration<Book>
    {
        protected override void Map(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Books");
        }
        protected override IEnumerable<Book> SeedData()
        {
            return new List<Book>()
            {
                new Book(){
                    Id = Guid.Parse("c3c64f20-e40e-437c-8952-b6dab6b4513a"),
                    Name = "Africanus",
                    AuthorId = Guid.Parse("64c3d8f1-723f-4a05-a8a6-af6329ea5781"),
                },
                new Book(){
                    Id = Guid.Parse("41fad579-629f-49ff-855e-36b88cf29cb9"),
                    Name = "Las legiones malditas",
                    AuthorId = Guid.Parse("64c3d8f1-723f-4a05-a8a6-af6329ea5781"),
                }
            };
        }
    }
}