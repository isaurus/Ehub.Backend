using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;

namespace eHub.Backend.WebApi.Registration
{
    public static class SwaggerRegistration
    {
        public static IServiceCollection AddSwaggerServices(this IServiceCollection services)
        {
            var enabled = Application.Registration.ConfigurationManager.SwaggerEnabled;

            if (enabled)
            {
                // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
                services.AddEndpointsApiExplorer();

                // FALTA AÑADIR 'AddSecurityDefinitions' y 'AddSecurityRequirement'
                services.AddSwaggerGen(c =>
                {
                    c.ExampleFilters();
                    c.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Version = "v1",
                        Title = "eHub - El portal para los profesionales de esports",
                        Description = "RESTful API con Clean Architecture para gestionar eHub",
                        Contact = new OpenApiContact
                        {
                            Name = "Isaac Martín",
                            Email = "isaacmartin.dev@gmail.com",
                            Url = new Uri("https://github.com/isaurus"),
                        },
                        License = new OpenApiLicense
                        {
                            Name = "MIT License",
                            Url = new Uri("https://opensource.org/licenses/MIT")
                        },
                    });

                    // Configuración para XML Comments
                    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFilename);
                    var domainXml = Path.Combine(AppContext.BaseDirectory, "eHub.Backend.Domain.xml");

                    if (File.Exists(xmlPath) && File.Exists(domainXml))
                    {
                        c.IncludeXmlComments(xmlPath);
                        c.IncludeXmlComments(domainXml);    // ¡NUEVO!
                    }
                    else
                    {
                        // Opcional: Loggear advertencia si el archivo no existe
                        Console.WriteLine($"XML documentation file not found: {xmlPath}");
                    }
                });

                services.AddSwaggerExamplesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());     // ¡NUEVO!
            }

            return services;
        }
    }
}