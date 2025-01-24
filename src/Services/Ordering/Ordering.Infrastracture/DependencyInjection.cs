using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ordering.Infrastracture.Data;
using Ordering.Infrastructure.Data.Interceptors;

namespace Ordering.Infrastracture
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Database");

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.AddInterceptors(new AuditableEntityInterceptor());
                options.UseSqlServer(connectionString);

            });

            return services;
        }
    }
}
