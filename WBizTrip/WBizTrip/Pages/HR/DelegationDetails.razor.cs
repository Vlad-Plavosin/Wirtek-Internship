using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.JsonPatch;
using WBizTrip.Domain.DTO;
using WBizTrip.Domain.Enums;

namespace WBizTrip.Client.Pages.HR
{
    public partial class DelegationDetails
    {
        [Parameter]
        public int TripId { get; set; }
        public TripDto tripDto = new TripDto();
        public List<TripSuggestionDto> tripSuggestions = new List<TripSuggestionDto>()!;
        public bool IsDisabled = true;
        private int index = 1;
        private int itemsPerPage = 10;

        protected override async Task OnInitializedAsync()
        {
            tripDto = await TripService.GetTripById(TripId);
            tripSuggestions = await TripSuggestionService.GetTripSuggestionsByTripId(TripId);
            IsAllStatusChanged();
        }

        public void IsAllStatusChanged()
        {
            var changedStatus = tripSuggestions.All(t => t.Status != SuggestionStatus.Pending);
            if (changedStatus)
            {
                IsDisabled = false;
            }
        }

        public async void OnButtonClicked(TripSuggestionDto tripSuggestion, SuggestionStatus status)
        {
            if (status == SuggestionStatus.Rejected)
            {
                NavigationManager.NavigateTo($"/hr/delegation/{TripId}/rejection/{tripSuggestion.Id}");
            }
            else
            {
                tripSuggestion.Status = status;
                JsonPatchDocument<TripSuggestionDto> updateTripSuggestion = new JsonPatchDocument<TripSuggestionDto>();
                updateTripSuggestion.Replace(t => t.Status, tripSuggestion.Status);
                updateTripSuggestion.Replace(t => t.RequestedChanges, "");
                await TripSuggestionService.PatchTripSuggestion(tripSuggestion.Id, updateTripSuggestion);
            }
            IsAllStatusChanged();
            StateHasChanged();
        }

        public async void ChangeTripStatus()
        {
            JsonPatchDocument<TripDto> updateTrip = new JsonPatchDocument<TripDto>();

            var isAllSuggestionRejected = tripSuggestions.All(t => t.Status == SuggestionStatus.Rejected);
            if (isAllSuggestionRejected)
            {
                updateTrip.Replace(t => t.Status, StatusVariants.Declined);
                await TripService.PatchTrip(TripId, updateTrip);
            }
            else
            {
                updateTrip.Replace(t => t.Status, StatusVariants.Approved);
                await TripService.PatchTrip(TripId, updateTrip);
            }
            NavigationManager.NavigateTo("/hr/home");
        }
        public void ChangeIndex(int toWhat)
        {
            index = toWhat;
        }
    }
}
