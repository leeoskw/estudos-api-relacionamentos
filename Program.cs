
using estudos_api_relacionamentos.DataContext;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace estudos_api_relacionamentos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            ConfiguraBd(builder.Services, builder.Configuration);

            // possibilita "ciclo de referência" no entity framewok
            builder.Services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
                options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }

        static void ConfiguraBd(IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddDbContext<ApplicationContext>(options =>
                options.UseMySql(configuration.GetConnectionString("MySqlConnectionString"), new MySqlServerVersion(new Version(8, 0, 21))));
        }
    }
}