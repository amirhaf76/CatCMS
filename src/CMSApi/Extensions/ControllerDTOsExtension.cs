using CMSApi.Abstraction.Services.DTOs;
using CMSApi.Controllers;
using CMSApi.Controllers.DTOs.Requests;

namespace CMSApi.Extensions
{
    public static class ControllerDTOsExtension
    {
        public static TokenDto ToDto(this LoginRequest request)
        {
            return new TokenDto
            {
                Password = request.Password,
                Username = request.Username,
            };
        }

        public static RegisterDto ToDto(this RegisterRequest request)
        {
            return new RegisterDto
            {
                Password = request.Password,
                Username = request.Username,
            };
        }
        
        public static RegisterResponse ToResponse(this RegisterResult result)
        {
            return new RegisterResponse
            {
                Id = result.Id,
                Username = result.Username,
                Password = result.Password,
                Status = result.Status,
            };
        }



    }
}
