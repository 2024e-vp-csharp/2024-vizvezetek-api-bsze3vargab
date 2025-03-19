using Microsoft.EntityFrameworkCore;
using Vizvezetek.API.Data;      // Data mappában a DbContext.

namespace Vizvezetek.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            // MySQL Connection
            builder.Services.AddDbContext<VizvezetekContext>(options =>
                options.UseMySql(
                    builder.Configuration.GetConnectionString("DefaultConnection"),
                    new MySqlServerVersion(new Version(8, 0, 36)) // MySQL verziód alapján
                )
            );

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseAuthorization();
            app.MapControllers();
            app.Run();

        }


    }

}