using WBizTrip.Domain.DTO;
using WBizTrip.Domain.Model;

namespace WBizTrip.Services.Abstractions
{
    public interface ITeamLeaderService
    {
        public void CreateTeamLeader(TeamLeader teamLeader);
        public void UpdateTeamLeader(int id, TeamLeader teamLeader);
        public void DeleteTeamLeader(int Id);
        public IEnumerable<TeamLeaderDto> GetTeamLeaders();
        public Task<TeamLeaderDto> GetTeamLeaderByUserId(int UserId);
        public TeamLeaderDto GetTeamLeaderDtoById(int id);
        public TeamLeader GetTeamLeaderById(int id);
    }
}
