using CMS.Client.Services.Abstraction.DTOs;
using CMS.Client.Services.DTOs;

namespace CMS.Client.Services.Extensions
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
