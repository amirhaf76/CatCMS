namespace CMSApi
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
