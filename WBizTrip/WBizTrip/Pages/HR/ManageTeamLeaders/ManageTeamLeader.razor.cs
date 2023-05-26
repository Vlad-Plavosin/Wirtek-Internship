using WBizTrip.Client.Shared;
using WBizTrip.Domain.DTO;

namespace WBizTrip.Client.Pages.HR.ManageTeamLeaders
{
    public partial class ManageTeamLeader
    {
        private int id;
        private List<TeamLeaderDto> teamLeaders = new List<TeamLeaderDto>();
        private Confirm? DeleteConfirmation { get; set; }
        private int index = 1;
        private int itemsPerPage = 10;

        protected override async Task OnInitializedAsync()
        {
            teamLeaders = await TeamLeaderService.GetTeamLeaders();
        }

        protected void OnDeleteClicked(int Id)
        {
            DeleteConfirmation.Show();
            id = Id;
            StateHasChanged();
        }

        protected async Task OnDeleteConfirmed(bool deleteConfiremed)
        {
            if (deleteConfiremed)
            {
                await TeamLeaderService.DeleteTeamLeader(id);
                teamLeaders = await TeamLeaderService.GetTeamLeaders();
            }
        }
        public void ChangeIndex(int toWhat)
        {
            index = toWhat;
        }
    }
}
