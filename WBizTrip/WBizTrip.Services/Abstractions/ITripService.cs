using Microsoft.AspNetCore.JsonPatch;
using WBizTrip.Domain.DTO;
using JsonPatchDocument = Microsoft.AspNetCore.JsonPatch.JsonPatchDocument;

namespace WBizTrip.Services.Abstractions
{
    public interface ITripService
    {
        public void CreateTrip(TripDto tripDto);
        public IEnumerable<TripDto> GetTrips();
        public TripDto GetTripById(int id);
        public Task<TripDto> UpdateTripPatchAsync(int id, JsonPatchDocument<TripDto> tripDocument);
    }
}
