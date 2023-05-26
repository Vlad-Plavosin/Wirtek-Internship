using Microsoft.AspNetCore.JsonPatch;
using WBizTrip.Domain.DTO;

namespace WBizTrip.Client.Services.Abstractions
{
    public interface ITripService
    {
        public Task<List<TripDto>> GetTrips();
        public Task<TripDto> GetTripById(int id);
        public Task PatchTrip(int id, JsonPatchDocument<TripDto> tripDocument);
    }
}
