using API.Data;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DataContext>(option =>
            {
                option.UseSqlServer(config.GetConnectionString("DigitHubShopDBConnection"));
            });
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddCors();
            services.AddEndpointsApiExplorer();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services;

        }
    }
}
