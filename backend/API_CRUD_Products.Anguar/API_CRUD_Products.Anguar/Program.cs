using API_CRUD_Products.Anguar.Context;
using API_CRUD_Products.Anguar.IoC;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add logging
        //builder.Services.AddLogging();

        //builder.Services.ConfigConnectionString(builder.Configuration);
        // Configure MySQL Database Context
        builder.Services.AddDbContext<ProductsDbContext>(options =>
            options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
            ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));

        // Repository as dependency injection
        builder.Services.RegisterService();

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Swagger for API documentation
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}
