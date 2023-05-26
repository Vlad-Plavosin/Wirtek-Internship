using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBizTrip.Domain.Enums;

namespace WBizTrip.Domain.DTO
{
    public class TripDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Location { get; set; } = String.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Passenger count cannot be lower than 0!")]
        public int FlightPassengers { get; set; } = 0;
        [Range(0, int.MaxValue, ErrorMessage = "Passenger count cannot be lower than 0!")]
        public int CarPassengers { get; set; } = 0;
        [Range(0, int.MaxValue, ErrorMessage = "Passenger count cannot be lower than 0!")]
        public int TrainPassengers { get; set; } = 0;
        [Range(0, int.MaxValue, ErrorMessage = "Passenger count cannot be lower than 0!")]
        public int BusPassengers { get; set; } = 0;
        public int ClientId { get; set; }
        public LocalTransportType LocalTransportType { get; set; }
        public StatusVariants Status { get; set; }
    }
}
