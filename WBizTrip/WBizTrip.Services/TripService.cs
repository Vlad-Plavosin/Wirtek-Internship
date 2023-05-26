using Microsoft.AspNetCore.JsonPatch;
using WBizTrip.API.Data;
using WBizTrip.Domain.DTO;
using WBizTrip.Domain.Model;
using WBizTrip.Services.Abstractions;
using WBizTrip.Services.Exceptions;

namespace WBizTrip.Services
{
    public class TripService : ITripService
    {
        private readonly HttpClient httpClient;

        private readonly WBizTripDbContext _dbContext;
        private readonly IClientService _clientService;
        public TripService(WBizTripDbContext dbContext, IClientService clientService)
        {
            _dbContext = dbContext;
            _clientService = clientService;
        }

        public void CreateTrip(TripDto tripDto)
        {
            var trip = new Trip ()
            {
                Name = tripDto.Name,
                Location = tripDto.Location,
                StartDate = tripDto.StartDate,
                EndDate = tripDto.EndDate,
                FlightPassengers = tripDto.FlightPassengers,
                BusPassengers = tripDto.BusPassengers,
                TrainPassengers = tripDto.TrainPassengers,
                CarPassengers = tripDto.CarPassengers,
                Status = tripDto.Status,
                ClientId = tripDto.ClientId,
                Client = _clientService.GetClient(tripDto.ClientId)
            };
            _dbContext.Trips.Add(trip);
            _dbContext.SaveChanges();
        }

        public IEnumerable<TripDto> GetTrips()
        {
            var trips = _dbContext.Trips.ToList();
            var tripsDto = trips.Select(trip => new TripDto()
            {
                Id = trip.Id,
                Name = trip.Name,
                Location = trip.Location,
                StartDate = trip.StartDate,
                EndDate = trip.EndDate,
                FlightPassengers = trip.FlightPassengers,
                BusPassengers = trip.BusPassengers,
                TrainPassengers = trip.TrainPassengers,
                CarPassengers = trip.CarPassengers,
                Status = trip.Status

            });
            return tripsDto.ToList();
        }

        public TripDto GetTripById(int id)
        {
            var trip = _dbContext.Trips.Find(id);
            if (trip != null)
            {
                var tripDto = new TripDto()
                {
                    Id = trip.Id,
                    Name = trip.Name,
                    Location = trip.Location,
                    StartDate = trip.StartDate,
                    EndDate = trip.EndDate,
                    FlightPassengers = trip.FlightPassengers,
                    BusPassengers = trip.BusPassengers,
                    TrainPassengers = trip.TrainPassengers,
                    CarPassengers = trip.CarPassengers,
                    Status = trip.Status
                };
                return tripDto;
            }
            else
            {
                throw new TripNotFoundException("Trip not found!");
            }
        }

        public async Task<TripDto> UpdateTripPatchAsync(int id, JsonPatchDocument<TripDto> tripDocument)
        {
            var tripDto = GetTripById(id);
            if (tripDto != null)
            {

                tripDocument.ApplyTo(tripDto);
                var tripToUpdate = _dbContext.Trips.Find(id);

                tripToUpdate.Name = tripDto.Name;
                tripToUpdate.Location = tripDto.Location;
                tripToUpdate.StartDate = tripDto.StartDate;
                tripToUpdate.EndDate = tripDto.EndDate;
                tripToUpdate.FlightPassengers = tripDto.FlightPassengers;
                tripToUpdate.TrainPassengers = tripDto.TrainPassengers;
                tripToUpdate.BusPassengers = tripDto.BusPassengers;
                tripToUpdate.CarPassengers = tripDto.CarPassengers;
                tripToUpdate.Status = tripDto.Status;

                await _dbContext.SaveChangesAsync();
                return tripDto;
            }
            else
            {
                throw new TripNotFoundException("Trip not found!");
            }
        }
    }
}
