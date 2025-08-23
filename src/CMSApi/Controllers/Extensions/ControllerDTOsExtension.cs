using CMSApi.Abstraction.Services.DTOs;
using CMSApi.Controllers.DTOs.Requests;
using CMSApi.Controllers.DTOs.Responses;
using CMSCore.Abstraction.Models;
using Infrastructure.GenericRepository;

namespace CMSApi.Controllers.Extensions
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

        public static Pagination ToEntryFilter(this PaginationDto dto)
        {
            return new Pagination
            {
                Number = dto.Number,
                Size = dto.Size,
            };
        }


        public static CMSCore.Abstraction.Models.Host ToCoreModel(this CMSRepository.Models.Host host)
        {
            return new CMSCore.Abstraction.Models.Host
            {
                Id = host.Id,
                Title = host.Title, 
            };
        }

    }
}
