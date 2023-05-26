using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Xml.Linq;
using WBizTrip.Domain.DTO;
using WBizTrip.Domain.Enums;
using WBizTrip.Domain.Model;
using WBizTrip.Services;
using WBizTrip.Services.Abstractions;
using WBizTrip.Services.Exceptions;

namespace WBizTrip.Client.Pages
{
    public partial class LoginPage : ComponentBase
    {
        private UserDto user { get; set; } = new UserDto() { Email = String.Empty, Password = String.Empty };
        public List<User> users = new List<User>();

        private readonly IUserService _userService;

        protected override async Task OnInitializedAsync()
        {

            var token = await LocalStorage.GetItemAsync<string>("token");

            if (token != null)
            {
                await authStateProvider.GetAuthenticationStateAsync();

                var jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);
                var role = jwt.Claims.First(c => c.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role").Value;

                if (role == "HR")
                    NavManager.NavigateTo("https://localhost:7268/hr/home");
                else
                if (role == "Admin")
                    NavManager.NavigateTo("https://localhost:7268/admin/home");
                else
                if (role == "TeamLeader")
                    NavManager.NavigateTo("https://localhost:7268/teamleader/home");


            }
        }
        string LastSubmitResult { get; set; } = string.Empty;


        async Task HandleLogin()
        {
            LastSubmitResult = string.Empty;
            await LocalStorage.ClearAsync();

            var result = await Http.PostAsJsonAsync("user/login", user);
            var token = await result.Content.ReadAsStringAsync();


            if (token != String.Empty && token != "Invalid credentials!")
            {
                await LocalStorage.SetItemAsync("token", token);
                await authStateProvider.GetAuthenticationStateAsync();

                var jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);
                string role = jwt.Claims.First(c => c.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role").Value;

                if (role == "HR")
                    NavManager.NavigateTo("https://localhost:7268/hr/home");
                else
                if (role == "Admin")
                    NavManager.NavigateTo("https://localhost:7268/admin/home");
                else
                if (role == "TeamLeader")
                    NavManager.NavigateTo("https://localhost:7268/teamleader/home");

            }
            else
            {
                LastSubmitResult = "*email or password incorrect";
            }
         
        }
    }

}
