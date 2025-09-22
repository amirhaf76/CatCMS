using CMS.WebApi.DTOs;
using Microsoft.Extensions.Options;

namespace CMS.WebApi.SetUps
{
    public class JwtOptionsSetup : IConfigureOptions<JwtOptions>
    {
        private readonly IConfiguration _configuration;


        public JwtOptionsSetup(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public void Configure(JwtOptions options)
        {
            _configuration.GetSection(AppSettingsSections.JWT).Bind(options);
        }
    }
}
