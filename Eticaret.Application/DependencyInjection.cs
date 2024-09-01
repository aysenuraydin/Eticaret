using Microsoft.Extensions.DependencyInjection;
using Eticaret.Application.Abstract;
using Eticaret.Application.Concrete;
using Eticaret.Application.Repositories;
using Microsoft.Extensions.Configuration;

namespace Eticaret.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();

            services.AddScoped<ICartItemRepository, CartItemRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            services.AddScoped<IProductCommentRepository, ProductCommentRepository>();
            services.AddScoped<IProductImageRepository, ProductImageRepository>();
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            return services;
        }
    }
}
