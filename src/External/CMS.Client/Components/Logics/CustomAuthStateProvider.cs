using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace CMS.Client.Components.Logics
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private AuthenticationState _authenticationState;

        public CustomAuthStateProvider()
        {
            _authenticationState = new AuthenticationState(new ClaimsPrincipal());
        }


        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            return Task.FromResult(_authenticationState);
        }

        public void ChangeAuthenticationState(ClaimsPrincipal newState)
        {
            ArgumentNullException.ThrowIfNull(newState);

            _authenticationState = new AuthenticationState(newState);

            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
    }
}
