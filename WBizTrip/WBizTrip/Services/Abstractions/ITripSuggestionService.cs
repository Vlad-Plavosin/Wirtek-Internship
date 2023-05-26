using Microsoft.AspNetCore.JsonPatch;
using WBizTrip.Domain.DTO;

namespace WBizTrip.Client.Services.Abstractions
{
    public interface ITripSuggestionService
    {
        public Task<List<TripSuggestionDto>> GetTripSuggestionsByTripId(int tripId);
        public Task CreateTripSuggestion(TripSuggestionDto tripSuggestionDto);
        public Task PatchTripSuggestion(int id, JsonPatchDocument<TripSuggestionDto> patchDocument);
        public Task<TripSuggestionDto> GetTripSuggestionByTripId(int tripId, int tripSuggestionId);
    }
}
