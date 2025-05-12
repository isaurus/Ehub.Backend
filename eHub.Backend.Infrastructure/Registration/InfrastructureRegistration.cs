using eHub.Backend.Application.Registration;
using eHub.Backend.Domain.Contracts.Hash;
using eHub.Backend.Domain.Contracts.Repositories;
using eHub.Backend.Infrastructure.Context;
using eHub.Backend.Infrastructure.Hash;
using eHub.Backend.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eHub.Backend.Infrastructure.Registration
{
    public static class InfrastructureRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<AppDbContext>(options => options.UseSqlServer(ConfigurationManager.HomeLocalDB));
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(ConfigurationManager.LaptopLocalDB));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPasswordHasher, BCryptPasswordHasher>();

            return services;
        }
    }
}
