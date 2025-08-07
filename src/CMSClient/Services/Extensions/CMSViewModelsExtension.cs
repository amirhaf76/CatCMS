using CMSClient.Services.Abstraction.DTOs;
using CMSClient.Services.DTOs;

namespace CMSClient.Services.Extensions
{
    public static class CMSViewModelsExtension
    {
        public static LoginDto ToDto(this LoginVM loginVM)
        {
            return new LoginDto
            {
                Password = loginVM.Password,
                Username = loginVM.Username,
            };
        }
    }
}
