using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.JsonPatch;
using System.Net.Http.Json;
using WBizTrip.Domain.DTO;
using WBizTrip.Domain.Enums;

namespace WBizTrip.Client.Pages.Admin
{
    public partial class DelegationDetails
    {
        [Parameter]
        public int TripId { get; set; }
        public TripDto tripDto = new TripDto();
        public List<TripSuggestionDto> tripSuggestions = new List<TripSuggestionDto>()!;
        private int index = 1;
        private int itemsPerPage = 10;

        protected override async Task OnInitializedAsync()
        {
            tripDto = await TripService.GetTripById(TripId);
            tripSuggestions = await TripSuggestionService.GetTripSuggestionsByTripId(TripId);
        }

        async Task HandleSubmit()
        {
            JsonPatchDocument<TripDto> updateTrip = new JsonPatchDocument<TripDto>();
            updateTrip.Replace(t => t.Status, StatusVariants.Pending);
            await TripService.PatchTrip(TripId, updateTrip);
            await Http.PostAsJsonAsync("Email/send-email", new EmailDto()
            {
                Body = $"A new delegation named {tripDto.Name} scheduled on {tripDto.StartDate} requires their suggestions to be approved or denied",
                Subject = "Delegation approved by administrator!",
                Receivers = UserRole.HR
            });
            NavigationManager.NavigateTo("/admin/home");
        }
        public void ChangeIndex(int toWhat)
        {
            index = toWhat;
        }
    }
}
