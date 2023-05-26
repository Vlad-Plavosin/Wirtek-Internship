using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.JsonPatch;
using WBizTrip.Domain.DTO;
using WBizTrip.Domain.Enums;
using WBizTrip.Domain.Model;

namespace WBizTrip.Client.Pages.TeamLeader
{
    public partial class DelegationDetails
    {
        [Parameter]
        public int Id { get; set; }
        public TripDto trip = new TripDto();
        public List<TripSuggestionDto> tripSuggestions = new List<TripSuggestionDto>()!;
        private int index = 1;
        private int itemsPerPage = 10;
        public async Task FinishDelegation(TripSuggestionDto tripSuggestion)
        {
            trip.Status = StatusVariants.Finished;
            var updateTrip = new JsonPatchDocument<TripDto>();
            updateTrip.Replace(t => t.Status, trip.Status);
            await TripService.PatchTrip(trip.Id, updateTrip);
            JsonPatchDocument<TripSuggestionDto> updateTripSuggestion = new JsonPatchDocument<TripSuggestionDto>();
            foreach (var suggestion in tripSuggestions)
            {
                suggestion.Status = SuggestionStatus.Rejected;
                updateTripSuggestion.Replace(t => t.Status, suggestion.Status);
                await TripSuggestionService.PatchTripSuggestion(suggestion.Id, updateTripSuggestion);
            }
            tripSuggestion.Status = SuggestionStatus.Chosen;
            updateTripSuggestion.Replace(t => t.Status, tripSuggestion.Status);
            await TripSuggestionService.PatchTripSuggestion(tripSuggestion.Id, updateTripSuggestion);

            NavigationManager.NavigateTo("/teamleader/home");
        }
        protected override async Task OnInitializedAsync()
        {
            trip = await TripService.GetTripById(Id);
            tripSuggestions = await TripSuggestionService.GetTripSuggestionsByTripId(Id);
        }
        public void ChangeIndex(int toWhat)
        {
            index = toWhat;
        }
    }
}
