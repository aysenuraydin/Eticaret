using Microsoft.Extensions.DependencyInjection;
using Eticaret.Application.Services;
using Eticaret.Application.Services.Interfaces;

namespace Eticaret.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ICategoryService, CategoryService>();

            return services;
        }
    }
}
