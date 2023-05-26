﻿using System.IdentityModel.Tokens.Jwt;
using WBizTrip.Domain.DTO;

namespace WBizTrip.Client.Pages.Admin
{
    public partial class Home
    {
        public List<TripDto>? trips = new List<TripDto>()!;
        private int index = 1;
        private int itemsPerPage = 10;

        string username;
        protected override async Task OnInitializedAsync()
        {
            var token = await LocalStorage.GetItemAsync<string>("token");

            if (token != null)
            {
                await authStateProvider.GetAuthenticationStateAsync();

                var jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);
                username = jwt.Claims.First(c => c.Type == "Name").Value;
            }
            trips = await TripService.GetTrips();
        }
        public void ChangeIndex(int toWhat)
        {
            index = toWhat;
        }
    }
}

