using CMS.Domain.Entities;
using CMS.Domain.ValueObjects;
using CMS.Presentation.Controllers.DTOs.Responses;

namespace CMS.Presentation.Controllers.Extensions
{
    public static class CMSServiceExtension
    {


        public static HostVM ToVM(this Host host)
        {
            return new HostVM
            {
                Id = host.Id,
                Title = host.Title,
                GeneratedCodesDirectory = host.GeneratedCodesDirectory,
                DomainAddress = host.DomainAddress,
            };
        }

        public static UserVM ToVM(this User user)
        {
            return new UserVM
            {
                Id = user.Id,
                Username = user.Username,
                Password = user.Password,
                Status = user.Status.ToVM(),
                Email = user.Email.Address,
            };
        }

        public static UserStatusVM ToVM(this UserStatus status)
        {
            return status switch
            {
                UserStatus.Active => UserStatusVM.Active,
                UserStatus.NotActivate => UserStatusVM.NotActivate,
                _ => throw new NotImplementedException(),
            };
        }

    }
}
