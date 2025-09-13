using CMS.Application.Abstraction.Services;
using CMS.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CMS.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddScoped<ICMSService, CMSService>()
                .AddScoped<IAuthenticationService, AuthenticationService>();

            return services;
        }
    }
}
