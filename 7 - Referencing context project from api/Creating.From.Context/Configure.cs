using System;
using System.Threading.Tasks;
using Creating.From.Context.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Creating.From.Context
{
    public static class ConfigureContext
    {

        public static async Task<IServiceCollection> ConfigureDbs(this IServiceCollection services, AppSettings appSettings)
        {
            await services.ConfigureDb<LibraryContext>(appSettings, appSettings.ConnectionStrings.Library, appSettings.Database.DbName);
            return services;
        }

        private static async Task ConfigureDb<TContext>(this IServiceCollection services, AppSettings settings, string connectionString, string dbName)
            where TContext : DbContext
        {
            if (settings.Database.UseInMemory)
            {
                services.AddDbContext<TContext>(o => o.UseInMemoryDatabase(dbName));
            }
            else
            {
                services.AddDbContext<TContext>(o => o.UseSqlServer(connectionString));
            }

            DbContextOptionsBuilder<TContext> optionsBuilder = new DbContextOptionsBuilder<TContext>();

            if (settings.Database.UseInMemory)
            {
                optionsBuilder.UseInMemoryDatabase(dbName);
            }
            else
            {
                optionsBuilder.UseSqlServer(connectionString);
            }

            var context = (TContext)Activator.CreateInstance(typeof(TContext), new object[] { optionsBuilder.Options });
            if (settings.Database.ApplyMigrations && !settings.Database.UseInMemory)
            {
                if (settings.Database.EnsureDeleted)
                {
                    await context.Database.EnsureDeletedAsync();
                }

                if (settings.Database.EnsureCreated)
                {
                    await context.Database.EnsureCreatedAsync();
                }

                if (settings.Database.ApplyMigrations)
                {
                    context.Database.Migrate();
                }
            }
        }
    }
}
