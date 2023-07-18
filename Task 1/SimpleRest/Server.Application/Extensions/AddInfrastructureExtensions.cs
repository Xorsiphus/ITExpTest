using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Server.Domain.Interfaces;
using Server.Infrastructure.Dal.Contexts;
using Server.Infrastructure.Dal.Repositories.Impl;

namespace Server.Application.Extensions
{
    public static class AddInfrastructureExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped<IMyObjectsRepository, MyObjectRepository>();

            services.AddDbContext<ServerAppContext>(options =>
                options.UseNpgsql(configuration["ConnectionString"]));

            return services;
        }
    }
}