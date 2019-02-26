namespace Creating.From.Context.Contexts.Mappings.Core
{
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public abstract class MappingsConfiguration<TEntity> : IMappingConfiguration
        where TEntity : class
    {
        public void Map(ModelBuilder builder)
        {
            var entityBuilder = builder.Entity<TEntity>();
            this.Map(entityBuilder);
            entityBuilder.HasData(this.SeedData());
        }

        protected virtual IEnumerable<TEntity> SeedData()
        {
            return new List<TEntity>();
        }

        protected abstract void Map(EntityTypeBuilder<TEntity> builder);
    }
}