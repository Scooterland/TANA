using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Security.Claims;
using TANA.Domain.Entities;

namespace TANA.Web.Authentication
{
    public class SessionAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ProtectedSessionStorage _sessionStorage;
        private const string SessionKey = "currentUser";

        private ClaimsPrincipal _anonymous = new(new ClaimsIdentity());

        public SessionAuthenticationStateProvider(ProtectedSessionStorage sessionStorage)
        {
            _sessionStorage = sessionStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var result = await _sessionStorage.GetAsync<Bruger>(SessionKey);
                var bruger = result.Success ? result.Value : null;

                if (bruger == null)
                    return new AuthenticationState(_anonymous);

                var identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, bruger.Email),
                    new Claim(ClaimTypes.Role, bruger.Rolle)
                }, "apiauth");

                var user = new ClaimsPrincipal(identity);
                return new AuthenticationState(user);
            }
            catch
            {
                return new AuthenticationState(_anonymous);
            }
        }

        public async void MarkUserAsAuthenticated(Bruger bruger)
        {
            await _sessionStorage.SetAsync(SessionKey, bruger);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public async void MarkUserAsLoggedOut()
        {
            await _sessionStorage.DeleteAsync(SessionKey);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
    }
}
