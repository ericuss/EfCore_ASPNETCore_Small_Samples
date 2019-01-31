namespace Creating.From.ConsoleApp.Contexts.Mappings
{
    using System;
    using System.Collections.Generic;
    using Core;
    using Creating.From.ConsoleApp.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class AuthorMappings : MappingsConfiguration<Author>
    {
        protected override void Map(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Books).WithOne(x => x.Author).HasForeignKey(x => x.AuthorId);
            builder.ToTable("Authors");
        }
        protected override IEnumerable<Author> SeedData()
        {
            return new List<Author>()
            {
                new Author() { Id = Guid.Parse("64c3d8f1-723f-4a05-a8a6-af6329ea5781"), Name = "Santiago Posteguillo"},
                new Author() { Id = Guid.Parse("8ef6815b-ebf8-4f2f-b25f-fd7530025723"), Name = "Simon Scarrow" },
                new Author() { Id = Guid.Parse("b343ac23-0e8d-4abf-88a0-7beacaf8caff"), Name = "Steven Pressfiel" },
                new Author() { Id = Guid.Parse("b3dbb82a-5387-466a-a99d-4b9d83903bdb"), Name = "Orson Scott" },
                new Author() { Id = Guid.Parse("7aba4e5e-309a-49b7-a8f4-f5fb64ad09cd"), Name = "John Scalzi" }
            };

        }
    }
}