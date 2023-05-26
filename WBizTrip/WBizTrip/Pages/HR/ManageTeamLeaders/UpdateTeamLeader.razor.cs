using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using WBizTrip.Domain.DTO;

namespace WBizTrip.Client.Pages.HR.ManageTeamLeaders
{
    public partial class UpdateTeamLeader
    {
        [Parameter]
        public int Id { get; set; }
        private TeamLeaderDto? teamLeaderDto = new TeamLeaderDto();

        protected override async Task OnInitializedAsync()
        {
            teamLeaderDto = await TeamLeaderService.GetTeamLeaderById(Id);
        }

        async Task HandleSubmit()
        {
            await TeamLeaderService.UpdateTeamLeader(Id, teamLeaderDto);
            NavigationManager.NavigateTo("/manage-teamleaders");
        }
    }
}
