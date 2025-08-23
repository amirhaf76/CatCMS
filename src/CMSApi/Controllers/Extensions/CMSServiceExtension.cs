namespace CMSApi.Controllers.Extensions
{
    public static class CMSServiceExtension
    {


        public static HostVM ToVM(this CMSRepository.Models.Host host)
        {
            return new HostVM
            {
                Id = host.Id,
                Title = host.Title,
                GeneratedCodesDirectory = host.GeneratedCodesDirectory,
                DomainAddress = host.DomainAddress,
            };
        }

        public static UserVM ToVM(this CMSRepository.Models.User user)
        {
            return new UserVM
            {
                Id = user.Id,
                Username = user.Username,
                Password = user.Password,
                Status = user.Status.ToVM(),
            };
        }

        public static UserStatusVM ToVM(this CMSRepository.Models.UserStatus status)
        {
            return status switch
            {
                CMSRepository.Models.UserStatus.Active => UserStatusVM.Active,
                CMSRepository.Models.UserStatus.NotActivate => UserStatusVM.NotActivate,
                _ => throw new NotImplementedException(),
            };
        }

    }
}
