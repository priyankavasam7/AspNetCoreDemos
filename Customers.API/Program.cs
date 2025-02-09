using Customers.API.Data;
using Customers.API.Repository;
using Microsoft.EntityFrameworkCore;

namespace Customers.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddScoped<ICustomerEFRepository,CustomerEFCoreInMemeoryRepository>();
            builder.Services.AddDbContext<CustomerDbContext>(options=>
            {
                options.UseInMemoryDatabase("CustomerDB");
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
