using eHub.Backend.Application.Registration;
using eHub.Backend.Business.Registration;
using eHub.Backend.Infrastructure.Registration;
using eHub.Backend.WebApi.Registration;
using eHub.Backend.WebApi.Builders;

using MicroElements.Swashbuckle.FluentValidation.AspNetCore;

using FluentValidation.AspNetCore;

namespace eHub.Backend.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // Registro de servicios (directorios 'Registration')
            builder.Services
                .AddApplicationServices(builder.Configuration)
                .AddBusinessServices()
                .AddInfrastructureServices(builder.Configuration)
                .AddSwaggerServices();

            /*
            builder.Services.AddBusinessServices();
            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddSwaggerServices();
            */

            builder.Services.AddFluentValidation(conf =>
                conf.RegisterValidatorsFromAssemblyContaining<Application.Features.User.Validators.UserModelValidator>());

            builder.Services.AddFluentValidationRulesToSwagger();

            builder.Services.AddControllers();

            var app = builder.Build();

            app.AddSwaggerApp();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
