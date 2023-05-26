using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using WBizTrip.Domain.DTO;
using WBizTrip.Domain.Enums;
using WBizTrip.Domain.Model;
using WBizTrip.Services.Abstractions;

namespace WBizTrip.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamLeaderController : Controller
    {
        private readonly ITeamLeaderService _teamLeaderService;
        private readonly IUserService _userService;

        public TeamLeaderController(ITeamLeaderService teamLeaderService, IUserService userService)
        {
            _teamLeaderService = teamLeaderService;
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TeamLeaderDto>> GetTeamLeaders()
        {
            try
            {
                return Ok(_teamLeaderService.GetTeamLeaders());
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetTeamLeader(int id)
        {
            try
            {
                return Ok(_teamLeaderService.GetTeamLeaderById(id));
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpGet("user/{id}")]
        public Task<TeamLeaderDto> GetTeamLeaderByUserId(int id)
        {
            try
            {
                var teamLeaderDto = _teamLeaderService.GetTeamLeaderByUserId(id);
                return teamLeaderDto;
            }
            catch (Exception e)
            {
                 throw new Exception(e.Message);
            }
        }

        [HttpPost("create")]
        public IActionResult CreateTeamLeader([FromBody] TeamLeaderDto teamLeaderDto)
        {
            var user = new User()
            {
                Name = teamLeaderDto.Name,
                Password = teamLeaderDto.Password,
                Email = teamLeaderDto.Email,
                Role = UserRole.TeamLeader,
            };
            try
            {
                _userService.CreateUser(user);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
            var teamLeader = new TeamLeader()
            {
                Team = teamLeaderDto.Team,
                User = user,
                UserId = user.Id
            };
            try
            {
                _teamLeaderService.CreateTeamLeader(teamLeader);
                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateTeamLeader(int id, [FromBody] TeamLeaderDto TeamLeaderDto)
        {
            var teamLeader = new TeamLeader()
            {
                Team = TeamLeaderDto.Team
            };

            try
            {
                _teamLeaderService.UpdateTeamLeader(id, teamLeader);
                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteClient(int id)
        {
            try
            {
                _teamLeaderService.DeleteTeamLeader(id);
                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
