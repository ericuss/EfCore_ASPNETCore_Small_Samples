namespace Creating.From.ConsoleApp.Contexts.Mappings
{
    using System;
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
    }
}