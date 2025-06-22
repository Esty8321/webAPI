//using Entities;
using Microsoft.EntityFrameworkCore;
using NLog.Web;
using repositories;
using Services;
internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        
        
        builder.Services.AddTransient<IUserRepository, UserRepository>();
        builder.Services.AddTransient<IUserService, UserService>();
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        //builder.Services.AddAutoMapper(typeof(AutoMapperProfile)); // Make sure this class exists

        builder.Services.AddTransient<IProductRepository, ProductRepository>();
        builder.Services.AddTransient<IProductService, ProductService>();
        builder.Services.AddTransient<IProductService, ProductService>();
        builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
        builder.Services.AddTransient<ICategoryService, CategoryService>();
        builder.Services.AddTransient<IOrderRepository, OrderRepository>();
        builder.Services.AddTransient<IOrderService, OrderService>();
       
        builder.Services.AddDbContext<webApiServerContext>(options =>
        //options.UseSqlServer("Data Source=SRV2\\PUPILS;Initial Catalog=webIceCreamStore;Integrated Security=True;TrustServerCertificate=True"));
        //options.UseSqlServer("Data Source=DESKTOP-IN2P6D4;Initial Catalog=IceCreamStore;Integrated Security=True;TrustServerCertificate=True")
         options.UseSqlServer(builder.Configuration.GetConnectionString("Home"))//??how need i call for the connection string??
        );

        builder.Host.UseNLog();

        builder.Services.AddControllers();
        builder.Services.AddOpenApi();

        var app = builder.Build();

        //builder.Services.AddEndpointsApiExplorer();
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            object value = app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/openapi/v1.json", "My API V1");
            });
        }

        app.UseHttpsRedirection();


        ///end


        // Configure the HTTP request pipeline.

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}