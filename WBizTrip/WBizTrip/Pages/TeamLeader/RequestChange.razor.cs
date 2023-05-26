using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.JSInterop;
using WBizTrip.Domain.DTO;
using WBizTrip.Domain.Enums;
using WBizTrip.Domain.Model;
using static System.Net.WebRequestMethods;

namespace WBizTrip.Client.Pages.TeamLeader
{
    public partial class RequestChange
    {
        [Parameter]
        public int Id { get; set; }
        public string RequestedChanges { get; set; } = string.Empty;//this will be changed in a future story<333333333333333333
        public TripDto trip = new TripDto();
        public List<TripSuggestionDto> tripSuggestions;
        protected override async Task OnInitializedAsync()
        {
            await Js.InvokeVoidAsync("ChangeBackButton", "/teamleader/home");
            trip = await TripService.GetTripById(Id);
            tripSuggestions = await TripSuggestionService.GetTripSuggestionsByTripId(Id);
        }
        public void CancelChange()
        {
            NavigationManager.NavigateTo($"/teamleader/delegation/{Id}");
        }
        async Task HandleSubmit()
        {
            trip.Status = StatusVariants.RequestedChange;
            var updateTrip = new JsonPatchDocument<TripDto>();
            updateTrip.Replace(t => t.Status, trip.Status);
            await TripService.PatchTrip(trip.Id, updateTrip);
            JsonPatchDocument<TripSuggestionDto> updateTripSuggestion = new JsonPatchDocument<TripSuggestionDto>();
            foreach (var suggestion in tripSuggestions)
            {
                suggestion.Status = SuggestionStatus.Pending;
                updateTripSuggestion.Replace(t => t.Status, suggestion.Status);
                await TripSuggestionService.PatchTripSuggestion(suggestion.Id, updateTripSuggestion);
            }
            NavigationManager.NavigateTo("/teamleader/home");
        }
    }
}
