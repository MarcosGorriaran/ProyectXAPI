
using ProyectXAPI.Connections;

namespace ProyectXAPI
{
    public class Program
    {
        const string PostgressConStringName = "DefaultConnection";
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            SessionFactoryCloud.ConnectionString = builder.Configuration.GetConnectionString(PostgressConStringName) ?? String.Empty;
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
    }
}
