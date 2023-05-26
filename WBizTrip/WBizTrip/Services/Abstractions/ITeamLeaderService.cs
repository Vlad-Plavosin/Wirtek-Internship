using WBizTrip.Domain.DTO;

namespace WBizTrip.Client.Services.Abstractions
{
	public interface ITeamLeaderService
	{
		Task<List<TeamLeaderDto>> GetTeamLeaders();
		Task<TeamLeaderDto> GetTeamLeaderById(int id);
		public Task<TeamLeaderDto> GetTeamLeaderByUserId(int UserId);

        Task CreateTeamLeader(TeamLeaderDto newTeamLeaderDto);
		Task UpdateTeamLeader(int id, TeamLeaderDto teamLeaderDto);
		Task DeleteTeamLeader(int id);
	}
}
