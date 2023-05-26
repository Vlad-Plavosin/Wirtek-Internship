using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json.Linq;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Xml.Linq;
using WBizTrip.Domain.DTO;
using WBizTrip.Domain.Enums;
using WBizTrip.Services;

namespace WBizTrip.Client.Pages.TeamLeader
{
    public partial class RequestDelegation
    {
        private TripDto newTrip = new TripDto() { StartDate = DateTime.Now, EndDate = DateTime.Now };
        private List<ClientDto> clients = new List<ClientDto>();
        private TeamLeaderDto teamLeader = new TeamLeaderDto();
        int CurrentUserId;
        private bool loading = false;
        protected override async Task OnInitializedAsync()
        {
            var token = await LocalStorage.GetItemAsync<string>("token");

            if (token != null)
            {
                await authStateProvider.GetAuthenticationStateAsync();

                var jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);
                CurrentUserId = int.Parse(jwt.Claims.First(c => c.Type == "Id").Value);
            }

            teamLeader = await TeamLeaderService.GetTeamLeaderByUserId(CurrentUserId);
    
            clients = (await ClientService.GetClientFromTeamLeaderId(teamLeader.Id)).ToList();
        }
        public void OnStartingDateChange(DateTime? selectedValue)
        {
            if (selectedValue > newTrip.EndDate)
                newTrip.EndDate = selectedValue ?? DateTime.Now;
        }
        async Task HandleSubmit()
        {
            newTrip.Status = StatusVariants.New;
            loading = !loading;
            await Http.PostAsJsonAsync("Trip/add-trip", newTrip);
            await Http.PostAsJsonAsync("Email/send-email", new EmailDto()
            {
                Body = $"A new delegation named {newTrip.Name} scheduled on {newTrip.StartDate} requires their costs to be filled in",
                Subject = "New delegation requested!",
                Receivers = UserRole.Admin
            });
            NavigationManager.NavigateTo("/teamleader/home");

        }
    }
}
