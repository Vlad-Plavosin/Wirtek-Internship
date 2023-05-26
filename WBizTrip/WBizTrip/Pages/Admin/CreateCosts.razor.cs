using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using WBizTrip.Domain.DTO;
using WBizTrip.Domain.Model;

namespace WBizTrip.Client.Pages.Admin
{
	public partial class CreateCosts
	{
		[Parameter]
		public int TripId { get; set; }
		public TripSuggestionDto? tripSuggestionDto = new TripSuggestionDto();

        protected override async Task OnInitializedAsync()
		{
            await Js.InvokeVoidAsync("ChangeBackButton", "/teamleader/home");
        }
        public async Task HandleSubmit()
		{
			var trip = await TripService.GetTripById(TripId);
			tripSuggestionDto.Trip = trip;
			await TripSuggestionService.CreateTripSuggestion(tripSuggestionDto);
			NavigationManager.NavigateTo($"/admin/delegation/{TripId}");
		}
	}
}
