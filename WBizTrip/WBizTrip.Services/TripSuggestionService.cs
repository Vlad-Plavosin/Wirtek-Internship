using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using WBizTrip.API.Data;
using WBizTrip.Domain.DTO;
using WBizTrip.Domain.Enums;
using WBizTrip.Domain.Model;
using WBizTrip.Services.Abstractions;
using WBizTrip.Services.Exceptions;

namespace WBizTrip.Services
{
    public class TripSuggestionService : ITripSuggestionService
    {
        private readonly WBizTripDbContext _dbContext;

        public TripSuggestionService(WBizTripDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<TripSuggestionDto> GetTripSuggestionsByTripId(int tripId)
        {
            var tripSuggestions = _dbContext.TripSuggestions.Include(ts => ts.Trip).Where(ts => ts.Trip.Id == tripId).ToList();
            var tripSuggestionsDto = tripSuggestions.Select(ts => new TripSuggestionDto()
            {
                Id = ts.Id,
                TransportInfo = ts.TransportInfo,
                TransportBudget = ts.TransportBudget,
                AccommodationInfo = ts.AccommodationInfo,
                AccommodationBudget = ts.AccommodationBudget,
                FoodBudget = ts.FoodBudget,
                Status = ts.Status,
                RequestedChanges = ts.RequestedChanges,
                Trip = new TripDto()
                {
                    Id = ts.Trip.Id,
                    Name = ts.Trip.Name,
                    Location = ts.Trip.Location,
                    StartDate = ts.Trip.StartDate,
                    EndDate = ts.Trip.EndDate,
                    FlightPassengers = ts.Trip.FlightPassengers,
                    BusPassengers = ts.Trip.BusPassengers,
                    TrainPassengers = ts.Trip.TrainPassengers,
                    CarPassengers = ts.Trip.CarPassengers,
                    LocalTransportType = ts.Trip.LocalTransportType,
                    Status = ts.Trip.Status
                }
            });
            return tripSuggestionsDto.ToList();
        }

        public TripSuggestionDto GetTripSuggestionByTripId(int tripId, int tripSuggestionId)
        {
            var tripSuggestion = _dbContext.TripSuggestions.Include(ts => ts.Trip).FirstOrDefault(ts => ts.Trip.Id == tripId && ts.Id == tripSuggestionId);
            if (tripSuggestion != null)
            {
                var tripSuggestionsDto = new TripSuggestionDto()
                {
                    Id = tripSuggestion.Id,
                    TransportInfo = tripSuggestion.TransportInfo,
                    TransportBudget = tripSuggestion.TransportBudget,
                    AccommodationInfo = tripSuggestion.AccommodationInfo,
                    AccommodationBudget = tripSuggestion.AccommodationBudget,
                    FoodBudget = tripSuggestion.FoodBudget,
                    Status = tripSuggestion.Status,
                    RequestedChanges = tripSuggestion.RequestedChanges,
                    Trip = new TripDto()
                    {
                        Id = tripSuggestion.Trip.Id,
                        Name = tripSuggestion.Trip.Name,
                        Location = tripSuggestion.Trip.Location,
                        StartDate = tripSuggestion.Trip.StartDate,
                        EndDate = tripSuggestion.Trip.EndDate,
                        FlightPassengers = tripSuggestion.Trip.FlightPassengers,
                        BusPassengers = tripSuggestion.Trip.BusPassengers,
                        TrainPassengers = tripSuggestion.Trip.TrainPassengers,
                        CarPassengers = tripSuggestion.Trip.CarPassengers,
                        LocalTransportType = tripSuggestion.Trip.LocalTransportType,
                        Status = tripSuggestion.Trip.Status
                    }
                };
                return tripSuggestionsDto;
            }
            else
            {
                throw new TripSuggestionNotFoundException("Trip Suggestion not found!");
            }
        }

        public void CreateTripSuggestion(TripSuggestionDto tripSuggestionDto)
        {
            var trip = _dbContext.Trips.Find(tripSuggestionDto.Trip.Id);
            var tripSuggestion = new TripSuggestion()
            {
                TransportInfo = tripSuggestionDto.TransportInfo,
                TransportBudget = tripSuggestionDto.TransportBudget,
                AccommodationInfo = tripSuggestionDto.AccommodationInfo,
                AccommodationBudget = tripSuggestionDto.AccommodationBudget,
                FoodBudget = tripSuggestionDto.FoodBudget,
                Status = SuggestionStatus.Pending,
                Trip = trip
            };
            _dbContext.TripSuggestions.Add(tripSuggestion);
            _dbContext.SaveChanges();
        }

        public void UpdatePatchTripSuggestion(int id, JsonPatchDocument<TripSuggestionDto> tripSuggestionDoc)
        {
            var tripSuggestionToUpdate = _dbContext.TripSuggestions.Find(id);
            if (tripSuggestionToUpdate != null)
            {
                var tripSuggestionDto = new TripSuggestionDto
                {
                    Id = tripSuggestionToUpdate.Id,
                    TransportInfo = tripSuggestionToUpdate.TransportInfo,
                    TransportBudget = tripSuggestionToUpdate.TransportBudget,
                    AccommodationInfo = tripSuggestionToUpdate.AccommodationInfo,
                    AccommodationBudget = tripSuggestionToUpdate.AccommodationBudget,
                    FoodBudget = tripSuggestionToUpdate.FoodBudget,
                    Status = tripSuggestionToUpdate.Status,
                    RequestedChanges = tripSuggestionToUpdate.RequestedChanges
                };

                tripSuggestionDoc.ApplyTo(tripSuggestionDto);

                tripSuggestionToUpdate.Id = tripSuggestionDto.Id;
                tripSuggestionToUpdate.TransportInfo = tripSuggestionDto.TransportInfo;
                tripSuggestionToUpdate.TransportBudget = tripSuggestionDto.TransportBudget;
                tripSuggestionToUpdate.AccommodationInfo = tripSuggestionDto.AccommodationInfo;
                tripSuggestionToUpdate.AccommodationBudget = tripSuggestionDto.AccommodationBudget;
                tripSuggestionToUpdate.FoodBudget = tripSuggestionDto.FoodBudget;
                tripSuggestionToUpdate.Status = tripSuggestionDto.Status;
                tripSuggestionToUpdate.RequestedChanges = tripSuggestionDto.RequestedChanges;

                _dbContext.SaveChanges();
            }
            else
            {
                throw new TripSuggestionNotFoundException("Trip Suggestion not found!");
            }
        }
    }
}
