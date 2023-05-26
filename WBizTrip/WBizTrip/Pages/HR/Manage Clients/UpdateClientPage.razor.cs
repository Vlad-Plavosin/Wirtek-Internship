using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using WBizTrip.Domain.DTO;

namespace WBizTrip.Client.Pages.HR.Manage_Clients
{
    public partial class UpdateClientPage
    {
        [Parameter]
        public int Id { get; set; }
        private ClientDto client = new ClientDto();
        private List<TeamLeaderDto> teamLeaders = new List<TeamLeaderDto>();
        protected override async Task OnInitializedAsync()
        {
            client = await Http.GetFromJsonAsync<ClientDto>("Client/" + Id);
            teamLeaders = (await TeamLeaderService.GetTeamLeaders()).ToList();
        }
        async Task HandleSubmit(int Id)
        {
            await Http.PutAsJsonAsync("Client/update-client/" + Id, client);
            NavigationManager.NavigateTo("/manage-clients");
        }
    }
}
