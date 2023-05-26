using WBizTrip.Domain.Enums;

namespace WBizTrip.Domain.Model
{
    public class TripSuggestion
    {
        public int Id { get; set; }
        public string TransportInfo { get; set; } = String.Empty;
        public int TransportBudget { get; set; }
        public string AccommodationInfo { get; set; } = String.Empty;
        public int AccommodationBudget { get; set; }
        public int FoodBudget { get; set; }
        public SuggestionStatus Status { get; set; }
        public Trip Trip { get; set; }
        public string RequestedChanges { get; set; } = String.Empty;
    }
}