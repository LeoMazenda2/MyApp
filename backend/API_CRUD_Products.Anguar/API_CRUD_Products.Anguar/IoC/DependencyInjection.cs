using API_CRUD_Products.Anguar.Context;
using API_CRUD_Products.Anguar.Repositories;
using API_CRUD_Products.Anguar.Repositories._Category;
using Microsoft.EntityFrameworkCore;

namespace API_CRUD_Products.Anguar.IoC;

public static class DependencyInjection
{
    public static IServiceCollection ConfigConnectionString(this IServiceCollection services, IConfiguration configuration)
    {
        // Add DbContext with MySQL connection string
        services.AddDbContext<ProductsDbContext>(options =>
            options.UseMySql(
                configuration.GetConnectionString("DefaultConnection"),
                ServerVersion.AutoDetect(configuration.GetConnectionString("DefaultConnection"))
            )
        );

        return services;
    }

    public static IServiceCollection RegisterService(this IServiceCollection services)
    {        
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>)); 
        services.AddScoped<ICategoryRepository, CategoryRepository>();
       

        return services;
    }
}
