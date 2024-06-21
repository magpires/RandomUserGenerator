using API.Context;
using API.Services;
using API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<RandomUserGeneratorContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSqlConnection")));

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Services dependency injections
            builder.Services.AddScoped<IRandomUserService, RandomUserService>();
            builder.Services.AddScoped<HttpClient>();
            builder.Services.AddHttpClient<RandomUserService>();

            WebApplication app = builder.Build();

            // Ensure database is created
            using (IServiceScope scope = app.Services.CreateScope())
            {
                RandomUserGeneratorContext dbContext = scope.ServiceProvider.GetRequiredService<RandomUserGeneratorContext>();
                dbContext.Database.Migrate();
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapFallbackToFile("index.html");

            app.Run();
        }
    }
}
