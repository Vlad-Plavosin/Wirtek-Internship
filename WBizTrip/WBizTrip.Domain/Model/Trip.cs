using System.ComponentModel.DataAnnotations;
using WBizTrip.Domain.Enums;

namespace WBizTrip.Domain.Model
{
    public class Trip
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Location { get; set; } = String.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [Range(0, int.MaxValue)]
        public int FlightPassengers { get; set; }
        public int BusPassengers { get; set; }
        public int TrainPassengers { get; set; }
        public int CarPassengers { get; set; }
        public StatusVariants Status { get; set; }
        public LocalTransportType LocalTransportType { get; set; }
        public Client Client { get; set; }

        public int ClientId { get; set; }

        public List<TripSuggestion> TripSuggestions { get; set; }
    }
}
