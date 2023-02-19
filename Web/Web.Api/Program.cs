using Microsoft.Extensions.FileProviders;

namespace Web
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
            
            builder.Services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/public";
            });

            // Add configuration.
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(builder.Environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
            var config = configBuilder.Build();
            builder.Services.AddSingleton(config);

            // Register using Ioc container setup.
            var containerSetup = new Ioc.ContainerSetup();
            containerSetup.Configure(builder.Services, config.GetSection("Configuration").Get<Ioc.Configuration>());

            var app = builder.Build();

            // Configure the Http request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Add exception handler.
            app.UseExceptionHandler("/error");
        
            app.UseRouting();
            
            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Add SPA support.
            app.UseSpaStaticFiles();
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";
                spa.Options.DefaultPageStaticFileOptions = new StaticFileOptions
                {
                    FileProvider = new PhysicalFileProvider(
                        Path.Combine(Directory.GetCurrentDirectory(), "ClientApp", "public"))
                };

                // Adds proxy to SPA.
                if (app.Environment.IsDevelopment())
                {
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:8080");
                }
            });          

            app.Run();
        }
    }
}