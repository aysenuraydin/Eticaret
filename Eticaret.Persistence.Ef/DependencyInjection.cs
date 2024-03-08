using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Eticaret.Persistence.Ef
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EticaretDbContext>(opt =>
            {
                opt.UseSqlite(configuration.GetConnectionString("DbConnection"), b => b.MigrationsAssembly("Eticaret.Web.Mvc"));
            });

            return services;
        }

    }
}
