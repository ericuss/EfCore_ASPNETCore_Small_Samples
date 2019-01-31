namespace Creating.From.ConsoleApp.Contexts.Mappings.Core
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public abstract class MappingsConfiguration<TEntity> : IMappingConfiguration
        where TEntity : class
    {
        public void Map(ModelBuilder builder)
        {
            var entityBuilder = builder.Entity<TEntity>();
            this.Map(entityBuilder);
        }

        protected abstract void Map(EntityTypeBuilder<TEntity> builder);
    }
}