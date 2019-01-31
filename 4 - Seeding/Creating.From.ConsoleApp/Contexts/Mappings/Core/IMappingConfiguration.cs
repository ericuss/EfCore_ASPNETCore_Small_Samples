namespace Creating.From.ConsoleApp.Contexts.Mappings.Core
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public interface IMappingConfiguration
    {
        void Map(ModelBuilder b);
    }

    public interface IMappingConfiguration<T> : IMappingConfiguration
        where T : class
    {
        void Map(EntityTypeBuilder<T> builder);
    }
}