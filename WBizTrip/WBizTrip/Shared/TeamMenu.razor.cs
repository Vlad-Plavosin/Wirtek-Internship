using Radzen.Blazor;
using System.IdentityModel.Tokens.Jwt;

namespace WBizTrip.Client.Shared
{
    public partial class TeamMenu
    {
        private bool collapseNavMenu = true;
        private string? NavBarCssClass => collapseNavMenu ? null : "show";
        private string? NavButtonCssClass => collapseNavMenu ? "collapsed" : null;

        private string role = string.Empty;
        private string name = string.Empty;
        private string email = string.Empty;

        private void ToggleNavMenu()
        {
            collapseNavMenu = !collapseNavMenu;
        }

        public async void OnProfileMenuClick(RadzenProfileMenuItem args)
        {
            if (args.Value is "logout")
            {
                await LocalStorage.ClearAsync();
            }
        }

        protected override async Task OnInitializedAsync()
        {
            var token = await LocalStorage.GetItemAsync<string>("token");

            if (token != null)
            {
                await authStateProvider.GetAuthenticationStateAsync();

                var jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);
                role = jwt.Claims.First(c => c.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role").Value;
                name = jwt.Claims.First(c => c.Type == "Name").Value;
                email = jwt.Claims.First(c => c.Type == "Email").Value;
            }
        }
    }
}
