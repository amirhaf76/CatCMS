using CMSClient.Services.Abstraction.DTOs;
using Infrastructure.GeneratedAPIs.CMSAPI;

namespace CMSClient.Services.Extensions
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
