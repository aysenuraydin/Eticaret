using Microsoft.Extensions.DependencyInjection;
using Eticaret.Application.Abstract;
using Eticaret.Application.Concrete;
using Eticaret.Application.Repositories;

namespace Eticaret.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

            return services;
        }
    }
}
