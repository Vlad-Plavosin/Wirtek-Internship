using Microsoft.AspNetCore.JsonPatch;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;
using WBizTrip.Client.Services.Abstractions;
using WBizTrip.Domain.DTO;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace WBizTrip.Client.Services
{
    public class TripService : ITripService
    {
        private readonly HttpClient _httpClient;

        public TripService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<TripDto>> GetTrips()
        {
            var response = await _httpClient.GetAsync("Trip");
            return JsonSerializer.Deserialize<IEnumerable<TripDto>>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true }).ToList();
        }

        public async Task<TripDto> GetTripById(int id)
        {
            var response = await _httpClient.GetAsync($"Trip/{id}");
            return JsonSerializer.Deserialize<TripDto>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
        public async Task PatchTrip(int id, JsonPatchDocument<TripDto> tripDocument)
        {
            var tripAsJson = JsonConvert.SerializeObject(tripDocument);
            var response=await _httpClient.PatchAsync($"Trip/update/{id}", new StringContent(tripAsJson, Encoding.UTF8, "application/json-patch+json"));
            response.EnsureSuccessStatusCode();

        }

    }
}
