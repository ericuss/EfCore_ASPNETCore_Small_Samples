namespace Creating.From.ConsoleApp.Contexts.Mappings
{
    using System;
    using Core;
    using Creating.From.ConsoleApp.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BookMappings : MappingsConfiguration<Book>
    {
        protected override void Map(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Books");
        }
    }
}