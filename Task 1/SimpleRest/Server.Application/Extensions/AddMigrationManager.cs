using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Server.Infrastructure.Dal.Contexts;

namespace Server.Application.Extensions
{
    public static class AddMigrationManager
    {
        public static IServiceCollection ApplyPendingMigrations(this IServiceCollection services)
        {
            var sp = services.BuildServiceProvider();
            var context = sp.GetRequiredService<ServerAppContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            return services;
        }
    }
}