using Microsoft.AspNetCore.Mvc;
using WBizTrip.Domain.DTO;
using WBizTrip.Domain.Model;
using WBizTrip.Services.Abstractions;

namespace WBizTrip.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly ITeamLeaderService _teamLeaderService;
        public ClientController(IClientService clientService, ITeamLeaderService teamLeaderService)
        {
            _clientService = clientService;
            _teamLeaderService = teamLeaderService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientDto>>> GetClients()
        {
            try
            {
                var clients = await _clientService.GetClients();
                var clientsDto = clients.Select(client => new ClientDto()
                {
                    Id = client.Id,
                    Name = client.Name,
                    Address = client.Address,
                    PhoneNumber = client.PhoneNumber,
                    AnnualBudget = client.AnnualBudget,
                    TeamLeaderId = client.TeamLeaderId,
                    TeamLeader = _teamLeaderService.GetTeamLeaderDtoById(client.TeamLeaderId ?? 0)
                }).ToList();
                return Ok(clientsDto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClientDto>> GetClient(int Id)
        {
            try
            {
                var client = _clientService.GetClient(Id);
                return Ok(client);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("tl/{TeamLeaderId}")]

        public  Task<List<ClientDto>> GetClientByTeamLeaderId(int TeamLeaderId)
        {
            try
            {
                var client = _clientService.GetClientFromTeamLeaderId(TeamLeaderId);
                return client;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPost("add-client")]
        public IActionResult CreateClient([FromBody] ClientDto clientDto)
        {
            var teamLeader = _teamLeaderService.GetTeamLeaderById(clientDto.TeamLeaderId ?? 0);
            var client = new Client()
            {
                Address = clientDto.Address,
                AnnualBudget = clientDto.AnnualBudget,
                Name = clientDto.Name,
                PhoneNumber = clientDto.PhoneNumber,
                TeamLeader = teamLeader
            };

            try
            {
                _clientService.CreateClient(client);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("update-client/{id}")]
        public IActionResult UpdateClient(int id, [FromBody] ClientDto clientDto)
        {
            var teamLeader = _teamLeaderService.GetTeamLeaderById(clientDto.TeamLeaderId ?? 0);
            var client = new Client()
            {
                Address = clientDto.Address,
                AnnualBudget = clientDto.AnnualBudget,
                PhoneNumber = clientDto.PhoneNumber,
                TeamLeader = teamLeader
            };
            try
            {
                _clientService.UpdateClient(id, client);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("delete-client/{id}")]
        public IActionResult DeleteClient(int id)
        {
            try
            {
                _clientService.DeleteClient(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}