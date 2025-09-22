using CMS.Client.Services.Abstraction;
using CMS.Client.Services.DTOs;
using CMS.Client.Services.Extensions;
using CMS.Client.Components.Logics;

namespace CMS.Client.Services
{

    public class UserStatePublisherService
    {
        private readonly IAccountManagement _accountManagement;
        private readonly CustomAuthStateProvider _customAuthStateProvider;

        public UserStatePublisherService(IAccountManagement accountManagement, CustomAuthStateProvider customAuthStateProvider)
        {
            _accountManagement = accountManagement;
            _customAuthStateProvider = customAuthStateProvider;
        }

        public async Task LoginAsync(LoginVM loginVM)
        {
            var state = await _accountManagement.LoginAsync(loginVM.ToDto());

            if (state is null)
            {
                throw new InvalidOperationException("Login state can not be null! Error must be in another layer");
            }

            _customAuthStateProvider.ChangeAuthenticationState(state);
        }

    }
}
