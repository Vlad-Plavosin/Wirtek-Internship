using Microsoft.AspNetCore.JsonPatch;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;
using WBizTrip.Client.Services.Abstractions;
using WBizTrip.Domain.DTO;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace WBizTrip.Client.Services
{
    public class TripSuggestionService : ITripSuggestionService
    {
        private readonly HttpClient _httpClient;

        public TripSuggestionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<TripSuggestionDto>> GetTripSuggestionsByTripId(int tripId)
        {
            var response = await _httpClient.GetAsync($"TripSuggestion/{tripId}");
            return JsonSerializer.Deserialize<List<TripSuggestionDto>>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<TripSuggestionDto> GetTripSuggestionByTripId(int tripId,int tripSuggestionId)
        {
            var response = await _httpClient.GetAsync($"TripSuggestion/{tripId}/{tripSuggestionId}");
            return JsonSerializer.Deserialize<TripSuggestionDto>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task CreateTripSuggestion(TripSuggestionDto tripSuggestionDto)
        {
            var tripSuggestionAsJson = JsonSerializer.Serialize(tripSuggestionDto);
            await _httpClient.PostAsync("TripSuggestion/create", new StringContent(tripSuggestionAsJson, Encoding.UTF8, "application/json"));
        }

        public async Task PatchTripSuggestion(int id, JsonPatchDocument<TripSuggestionDto> patchDocument)
        {
            var tripSuggestionAsJson = JsonConvert.SerializeObject(patchDocument);
            await _httpClient.PatchAsync($"TripSuggestion/update/{id}", new StringContent(tripSuggestionAsJson, Encoding.UTF8, "application/json-patch+json"));
        }
    }
}
