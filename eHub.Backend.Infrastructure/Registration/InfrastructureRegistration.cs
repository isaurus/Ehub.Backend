using eHub.Backend.Application.Registration;
using eHub.Backend.Domain.Contracts.Repositories;
using eHub.Backend.Infrastructure.Context;
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
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(ConfigurationManager.LocalDB));

            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
