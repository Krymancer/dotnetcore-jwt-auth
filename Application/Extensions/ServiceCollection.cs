using Application.Authentication;
using Application.Authentication.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions
{
    public static class ServiceCollection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationManager, AuthenticationManager>();

            return services;
        }
    }
}
