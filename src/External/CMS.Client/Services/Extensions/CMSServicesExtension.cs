using CMS.Client.Services.Abstraction.DTOs;
using CMS.Infrastructure.GeneratedAPIs.CMSAPI;

namespace CMS.Client.Services.Extensions
{
    public static class CMSServicesExtension
    {
        public static LoginRequest ToRequest(this LoginDto loginDto)
        {
            return new LoginRequest
            {
                Password = loginDto.Password,
                Username = loginDto.Username,
            };
        }


    }
}
