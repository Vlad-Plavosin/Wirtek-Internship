namespace WBizTrip.Services.Exceptions
{
    public class TripSuggestionNotFoundException : Exception
    {
        public TripSuggestionNotFoundException()
        {
        }

        public TripSuggestionNotFoundException(string message) : base(message)
        {
        }

        public TripSuggestionNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
