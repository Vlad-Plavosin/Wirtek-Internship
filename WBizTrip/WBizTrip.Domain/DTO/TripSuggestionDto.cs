using System.ComponentModel.DataAnnotations;
using WBizTrip.Domain.Enums;

namespace WBizTrip.Domain.DTO
{
    public class TripSuggestionDto
    {
        public int Id { get; set; }
        public string TransportInfo { get; set; } = String.Empty;
        [Range(0, int.MaxValue, ErrorMessage = "Budget must be higher than 0!")]
        public int TransportBudget { get; set; }
        public string AccommodationInfo { get; set; } = String.Empty;
        [Range(0, int.MaxValue, ErrorMessage = "Budget must be higher than 0!")]
        public int AccommodationBudget { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Budget must be higher than 0!")]
        public int FoodBudget { get; set; }
        public SuggestionStatus Status { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Trip Id is not valid!")]
        public string RequestedChanges { get; set; } = String.Empty;
        public TripDto Trip { get; set; }
    }
}
