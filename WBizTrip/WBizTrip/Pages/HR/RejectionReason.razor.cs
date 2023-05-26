using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.JSInterop;
using WBizTrip.Domain.DTO;
using WBizTrip.Domain.Enums;

namespace WBizTrip.Client.Pages.HR
{
    public partial class RejectionReason
    {
        [Parameter]
        public int TripId { get; set; }
        [Parameter]
        public int TripSuggestionId { get; set; }
        public string RequestedChanges = string.Empty;

        async Task CancelChange()
        {
            var updateTripSuggestion = new JsonPatchDocument<TripSuggestionDto>();
            updateTripSuggestion.Replace(t => t.Status, SuggestionStatus.Pending);
            await TripSuggestionService.PatchTripSuggestion(TripSuggestionId, updateTripSuggestion);
            NavigationManager.NavigateTo($"/hr/delegation/{TripId}");
        }
        protected override async Task OnInitializedAsync()
        {
            await Js.InvokeVoidAsync("ChangeBackButton", "/hr/home");
        }

        async Task HandleSubmit()
        {
            var updateTripSuggestion = new JsonPatchDocument<TripSuggestionDto>();
            updateTripSuggestion.Replace(t => t.Status, SuggestionStatus.Rejected);
            updateTripSuggestion.Replace(t => t.RequestedChanges,RequestedChanges);
            await TripSuggestionService.PatchTripSuggestion(TripSuggestionId, updateTripSuggestion);
            NavigationManager.NavigateTo($"/hr/delegation/{TripId}");
        }
    }
}
