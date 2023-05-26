using System.Net.Http.Json;
using WBizTrip.Domain.DTO;
using WBizTrip.Domain.Model;
using WBizTrip.Services;

namespace WBizTrip.Client.Pages.HR.ManageTeamLeaders
{
    public partial class CreateTeamLeader
    {
        private TeamLeaderDto? newTeamLeaderDto = new TeamLeaderDto();
        async Task HandleSubmit()
        {
            await TeamLeaderService.CreateTeamLeader(newTeamLeaderDto!);
            NavigationManager.NavigateTo("/manage-teamleaders");
        }
    }
}
