using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace API.Extensions
{
    public static class DataBaseServicesExtensions
    {
        public static IServiceCollection AddDataBaseServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<StoreContext>(opt => 
            {
                opt.UseSqlServer(config.GetConnectionString("Default"));
            });
            services.AddDbContext<AppIdentityDbContext>(opt => 
            {
                opt.UseSqlServer(config.GetConnectionString("IdentityConnection"));
            });
            services.AddSingleton<IConnectionMultiplexer>(c =>
            {
                var configuration = ConfigurationOptions.Parse(config.GetConnectionString("Redis"), true);
                return ConnectionMultiplexer.Connect(configuration);
            });
            return services;
        }
    }
}