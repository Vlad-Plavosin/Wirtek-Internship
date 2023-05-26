using Microsoft.AspNetCore.JsonPatch;
using WBizTrip.Domain.DTO;

namespace WBizTrip.Services.Abstractions
{
    public interface ITripSuggestionService
    {
        public IEnumerable<TripSuggestionDto> GetTripSuggestionsByTripId(int tripId);
        public void CreateTripSuggestion(TripSuggestionDto tripSuggestionDto);
        public void UpdatePatchTripSuggestion(int id, JsonPatchDocument<TripSuggestionDto> tripSuggestionDoc);
        public TripSuggestionDto GetTripSuggestionByTripId(int tripId, int tripSuggestionId);
    }
}
