using CMS.WebApi.SetUps;

namespace CMS.WebApi.Extensions
{
    internal static class CMSConfigurationExtension
    {
        internal static IServiceCollection AddCMSConfiguration(this IServiceCollection services)
        {
            services.ConfigureOptions<JwtOptionsSetup>();

            return services;
        }
    }
}
