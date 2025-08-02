using CatCMS.Components.Logics;

namespace CatCMS.Services
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

        public async Task LoginAsync()
        {
            var state = await _accountManagement.LoginAsync();

            if (state is null)
            {
                throw new Exception();
            }

            _customAuthStateProvider.ChangeAuthenticationState(state);
        }

    }
}
