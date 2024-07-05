using Microsoft.EntityFrameworkCore;
using SmartPhones.API.Data;
using SmartPhones.API.Repository;

namespace SmartPhones.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddScoped<ISmartPhoneRepository,SmartPhoneRepository>();
            builder.Services.AddDbContext<SmartPhoneDbContext>(options =>
            {
                options.UseInMemoryDatabase("SmartPhoneDB");
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
