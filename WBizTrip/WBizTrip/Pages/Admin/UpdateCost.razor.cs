using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.JSInterop;
using WBizTrip.Domain.DTO;
using WBizTrip.Domain.Enums;

namespace WBizTrip.Client.Pages.Admin
{
    public partial class UpdateCost
    {
        [Parameter]
        public int TripId { get; set; }
        [Parameter]
        public int TripSuggestionId { get; set; }
        public TripSuggestionDto? tripSuggestionDto = new TripSuggestionDto();
        protected override async Task OnInitializedAsync()
        {
            tripSuggestionDto = await TripSuggestionService.GetTripSuggestionByTripId(TripId, TripSuggestionId);
            await Js.InvokeVoidAsync("ChangeBackButton", "/admin/home");
        }

        public async Task HandleSubmit()
        {
            var updateTripSuggestion = new JsonPatchDocument<TripSuggestionDto>();
            updateTripSuggestion.Replace(t => t.TransportInfo, tripSuggestionDto.TransportInfo);
            updateTripSuggestion.Replace(t => t.TransportBudget, tripSuggestionDto.TransportBudget);
            updateTripSuggestion.Replace(t => t.AccommodationInfo, tripSuggestionDto.AccommodationInfo);
            updateTripSuggestion.Replace(t => t.AccommodationBudget, tripSuggestionDto.AccommodationBudget);
            updateTripSuggestion.Replace(t => t.FoodBudget, tripSuggestionDto.FoodBudget);
            updateTripSuggestion.Replace(t => t.Status, SuggestionStatus.Pending);

            await TripSuggestionService.PatchTripSuggestion(TripSuggestionId, updateTripSuggestion);

            NavigationManager.NavigateTo($"/admin/delegation/{TripId}");
        }
    }
}
