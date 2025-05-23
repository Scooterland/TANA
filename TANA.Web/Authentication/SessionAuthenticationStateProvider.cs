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

        private readonly ClaimsPrincipal _anonymous = new(new ClaimsIdentity());

        public SessionAuthenticationStateProvider(ProtectedSessionStorage sessionStorage)
        {
            _sessionStorage = sessionStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var result = await _sessionStorage.GetAsync<AuthenticatedUser>(SessionKey);
                var user = result.Success ? result.Value : null;

                if (user == null)
                    return new AuthenticationState(_anonymous);

                var identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Email),
                    new Claim(ClaimTypes.Role, user.Rolle)
                }, "apiauth");

                return new AuthenticationState(new ClaimsPrincipal(identity)); 
            }
            catch
            {
                return new AuthenticationState(_anonymous);
            }
        }


        public async Task MarkUserAsAuthenticated(Bruger bruger)
        {
            var user = new AuthenticatedUser
            {
                Id = bruger.Id,
                Email = bruger.Email,
                Rolle = bruger.Rolle
            };

            await _sessionStorage.SetAsync(SessionKey, user);

            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
            Console.WriteLine($"[Auth] GetAuthenticationStateAsync: {user?.Email ?? "null"}");

        }

        public async Task MarkUserAsLoggedOut()
        {
            await _sessionStorage.DeleteAsync(SessionKey);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
    }
}
