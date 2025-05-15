using eHub.Backend.Application.Registration;
using eHub.Backend.Domain.Contracts.Repositories;
using eHub.Backend.Infrastructure.Context;
using eHub.Backend.Infrastructure.Security.Hash;
using eHub.Backend.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using eHub.Backend.Domain.Contracts.Services;
using eHub.Backend.Infrastructure.Security.Authentication;

namespace eHub.Backend.Infrastructure.Registration
{
    public static class InfrastructureRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<AppDbContext>(options => options.UseSqlServer(ConfigurationManager.HomeLocalDB));
            //services.AddDbContext<AppDbContext>(options => options.UseSqlServer(ConfigurationManager.LaptopLocalDB));
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(ConfigurationManager.RemoteDockerSQLServer));

            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPasswordHasherService, BCryptPasswordHasher>();
            services.AddSingleton<IAuthService, AuthService>();

            return services;
        }
    }
}
