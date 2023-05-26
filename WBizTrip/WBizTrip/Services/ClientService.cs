using System.Text.Json;
using WBizTrip.Client.Services.Abstractions;
using WBizTrip.Domain.DTO;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace WBizTrip.Client.Services
{
    public partial class ClientService : IClientService
    {
        private readonly HttpClient _httpClient;

        public ClientService (HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ClientDto>> GetClients()
        {
            var response = await _httpClient.GetAsync("Client");
            return JsonSerializer.Deserialize<IEnumerable<ClientDto>>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true }).ToList();
        }

        public async Task<List<ClientDto>> GetClientFromTeamLeaderId(int TeamLeaderId)
        {
            var response = await _httpClient.GetAsync($"Client/tl/{TeamLeaderId}");
            return JsonSerializer.Deserialize<IEnumerable<ClientDto>>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true }).ToList();
        }
    }
}
