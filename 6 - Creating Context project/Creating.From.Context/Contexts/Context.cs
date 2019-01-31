namespace Creating.From.Context.Contexts
{
    using System;
    using System.Linq;
    using Creating.From.Context.Contexts.Mappings.Core;
    using Microsoft.EntityFrameworkCore;

    public class Context : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var mappings = GetType().Assembly.DefinedTypes.Where(t =>
                typeof(IMappingConfiguration).IsAssignableFrom(t)
            //&& t.IsDefined(typeof(TContextAttribute), false)
            );

            foreach (var type in mappings.Where(m => !m.IsAbstract && !m.IsInterface))
            {
                var builder = (IMappingConfiguration)Activator.CreateInstance(type);
                builder.Map(modelBuilder);
            }
        }
    }
}