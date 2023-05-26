using System.Text;
using System.Text.Json;
using WBizTrip.Client.Services.Abstractions;
using WBizTrip.Domain.DTO;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace WBizTrip.Client.Services
{
    public class TeamLeaderService : ITeamLeaderService
    {
        private readonly HttpClient _httpClient;

        public TeamLeaderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<TeamLeaderDto>> GetTeamLeaders()
        {
            var response = await _httpClient.GetAsync("TeamLeader");
            return JsonSerializer.Deserialize<List<TeamLeaderDto>>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        }

        public async Task<TeamLeaderDto> GetTeamLeaderById(int id)
        {
            var response = await _httpClient.GetAsync($"TeamLeader/{id}");
            return JsonSerializer.Deserialize<TeamLeaderDto>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<TeamLeaderDto> GetTeamLeaderByUserId(int UserId)
        {
            var response = await _httpClient.GetAsync($"TeamLeader/user/{UserId}");
            return JsonSerializer.Deserialize<TeamLeaderDto>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task CreateTeamLeader(TeamLeaderDto newTeamLeaderDto)
        {
            var newTeamLeaderAsJson = JsonSerializer.Serialize(newTeamLeaderDto);
            await _httpClient.PostAsync("TeamLeader/create", new StringContent(newTeamLeaderAsJson, Encoding.UTF8, "application/json"));
        }

        public async Task UpdateTeamLeader(int id, TeamLeaderDto teamLeaderDto)
        {
            var teamLeaderAsJson = JsonSerializer.Serialize(teamLeaderDto);
            await _httpClient.PutAsync($"TeamLeader/update/{id}", new StringContent(teamLeaderAsJson, Encoding.UTF8, "application/json"));
        }

        public async Task DeleteTeamLeader(int id)
        {
            await _httpClient.DeleteAsync($"TeamLeader/delete/{id}");
        }


    }
}
