using CMS.Application.Abstraction.Services.DTOs;
using CMS.Domain.Entities;
using CMS.Presentation.Controllers.DTOs.Requests.Controllers.DTOs.Requests;
using SharedKernel;

namespace CMS.Presentation.Controllers.Extensions
{
    public static class ControllerDTOsExtension
    {
        public static TokenRequestDto ToDto(this LoginRequest request)
        {
            return new TokenRequestDto
            {
                Password = request.Password,
                Username = request.Username,
            };
        }

        public static RegisterRequestDto ToDto(this RegisterRequest request)
        {
            return new RegisterRequestDto
            {
                Password = request.Password,
                Username = request.Username,
            };
        }

        public static RegisterResult ToResponse(this RegisterResult result)
        {
            return new RegisterResult
            {
                Id = result.Id,
                Username = result.Username,
                Password = result.Password,
                Status = result.Status,
            };
        }

        public static Host ToCoreModel(this Host host)
        {
            return new Host
            {
                Id = host.Id,
                Title = host.Title,
            };
        }

    }
}
