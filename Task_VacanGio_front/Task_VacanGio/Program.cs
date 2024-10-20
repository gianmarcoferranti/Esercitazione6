
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Task_VacanGio.Models;
using Task_VacanGio.Repos;
using Task_VacanGio.Services;

namespace Task_VacanGio
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
            builder.Services.AddSwaggerGen(c =>
            {
                c.MapType<DateOnly>(() => new OpenApiSchema { Type = "string", Format = "date" });
                c.MapType<DateOnly?>(() => new OpenApiSchema { Type = "string", Format = "date" });
            });

            #region Importanti per la configurazione del context

#if DEBUG
            builder.Services.AddDbContext<VacanGioContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseTest"))
                );

            builder.Services.AddScoped<UtenteRepo>();
            builder.Services.AddScoped<DestinazioneRepo>();
            builder.Services.AddScoped<PacchettoRepo>();
            builder.Services.AddScoped<RecensioneRepo>();
            builder.Services.AddScoped<TrattaRepo>();

            builder.Services.AddScoped<UtenteService>();
            builder.Services.AddScoped<DestinazioneService>();
            builder.Services.AddScoped<PacchettoService>();
            builder.Services.AddScoped<RecensioneService>();
#else
            builder.Services.AddDbContext<VacanGioContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseProd"))
                );
#endif

            #endregion


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();
            #region Configurazione di dev per CORS
#if DEBUG
            app.UseCors(builder =>
            builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader()
            );
#endif
            #endregion

            app.Run();
        }
    }
}
