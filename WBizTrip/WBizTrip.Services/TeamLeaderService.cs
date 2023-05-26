using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using System.Text.Json;
using WBizTrip.API.Data;
using WBizTrip.Domain.DTO;
using WBizTrip.Domain.Model;
using WBizTrip.Services.Abstractions;

namespace WBizTrip.Services
{
    public class TeamLeaderService : ITeamLeaderService
    {
        private readonly WBizTripDbContext _dbContext;
        private readonly IUserService _userService;

        public TeamLeaderService(WBizTripDbContext dbContext, IUserService userService)
        {
            _dbContext = dbContext;
            _userService = userService;
        }
        public void CreateTeamLeader(TeamLeader teamLeader)
        {
            _dbContext.TeamLeaders.Add(teamLeader);
            _dbContext.SaveChanges();
        }
        public void DeleteTeamLeader(int Id)
        {
            var teamLeader = _dbContext.TeamLeaders.Find(Id);
            var user = _dbContext.Users.Find(teamLeader.UserId);
            if (user != null && teamLeader != null)
            {
                _dbContext.Users.Remove(user);
                _dbContext.TeamLeaders.Remove(teamLeader);
                _dbContext.SaveChanges();
            }
        }
        public void UpdateTeamLeader(int id, TeamLeader teamLeader)
        {
            var teamLeaderToUpdate = _dbContext.TeamLeaders.Find(id);
            if (teamLeaderToUpdate != null)
            {
                teamLeaderToUpdate.Team = teamLeader.Team;
                _dbContext.SaveChanges();
            }
        }
        public IEnumerable<TeamLeaderDto> GetTeamLeaders()
        {
            var users = _dbContext.Users.ToList();
            var teamLeaders = _dbContext.TeamLeaders.ToList();
            var teamLeaderDto = new TeamLeaderDto();
            var allTeamLeaders = users.Join(teamLeaders, u => u.Id, tl => tl.User.Id, (u, tl) => new TeamLeaderDto
            {
                Id = tl.Id,
                Name = u.Name,
                Email = u.Email,
                Team = tl.Team,
                UserId = tl.UserId
            });
            return allTeamLeaders.ToList();
        }
        public TeamLeader GetTeamLeaderById(int id)
        {
            return _dbContext.TeamLeaders.Find(id);
        }

        public TeamLeaderDto GetTeamLeaderDtoById(int id)
        {
            var teamLeader = _dbContext.TeamLeaders.Find(id);
            if (teamLeader != null)
            {
                var teamLeaderDto = new TeamLeaderDto()
                {
                    Team = teamLeader.Team,
                    UserId = teamLeader.UserId,
                    User = teamLeader.User
                };
                return teamLeaderDto;
            }
            else
            {
                throw new Exception("Team Leader not found!");
            }
        }

        public async Task<TeamLeaderDto> GetTeamLeaderByUserId(int UserId)
        {
            var teamLeader = _dbContext.TeamLeaders.Include(t => t.User).FirstOrDefault(t => t.UserId == UserId);
            if (teamLeader != null)
            {
                var teamLeaderDto = new TeamLeaderDto()
                {
                    Id = teamLeader.Id,
                    Team = teamLeader.Team,
                    Name = teamLeader.User.Name,
                    UserId = teamLeader.UserId
                };
                return teamLeaderDto;
            }
            else
            {
                throw new Exception("Team leader is not found!");
            }
        }
    }
}
