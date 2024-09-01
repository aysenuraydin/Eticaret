using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Eticaret.Persistence.Ef.Constants;

namespace Eticaret.Persistence.Ef
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EticaretDbContext>(opt =>
            {
                opt.UseSqlite(configuration.GetConnectionString(ConnectionSettings.DB_CONNECTION), b => b.MigrationsAssembly(ConnectionSettings.MİGRATİON_LAYER_NAME));
            });
            return services;
        }

    }
}


