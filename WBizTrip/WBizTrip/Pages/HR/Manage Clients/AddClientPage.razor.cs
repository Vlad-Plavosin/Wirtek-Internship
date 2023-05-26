using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using WBizTrip.Domain.DTO;


namespace WBizTrip.Client.Pages.HR.Manage_Clients
{
    public partial class AddClientPage
    {
        private ClientDto newClient = new ClientDto();
        private List<TeamLeaderDto> teamLeaders = new List<TeamLeaderDto>();

        protected override async Task OnInitializedAsync()
        {
            teamLeaders = (await TeamLeaderService.GetTeamLeaders()).ToList();
        }

        async Task HandleSubmit()
        {
            await Http.PostAsJsonAsync("Client/add-client", newClient);
            Logger.LogInformation("HandleValidSubmit called");
            NavigationManager.NavigateTo("/manage-clients");
        }
    }
}

