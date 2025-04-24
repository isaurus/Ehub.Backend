using eHub.Backend.Business.Services;
using eHub.Backend.Domain.Contracts.Services;
using Microsoft.Extensions.DependencyInjection;

namespace eHub.Backend.Business.Registration
{
    public static class BusinessRegistration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
