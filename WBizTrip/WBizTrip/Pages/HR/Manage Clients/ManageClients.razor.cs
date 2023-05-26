using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using WBizTrip.Client.Shared;
using WBizTrip.Domain.DTO;
using WBizTrip.Domain.Model;

namespace WBizTrip.Client.Pages.HR.Manage_Clients
{
    public partial class ManageClients
    {

        private ClientDto[] clients = default!;
        public ClientDto client { get; set; } = new ClientDto();
        private int id;
        private int index = 1;
        private int itemsPerPage = 10;
        private Confirm? DeleteConfirmation { get; set; }
        protected override async Task OnInitializedAsync()
        {
            clients = await Http.GetFromJsonAsync<ClientDto[]>("client");
        }

        protected void OnDeleteClicked(int Id)
        {
            DeleteConfirmation.Show();
            id = Id;
            StateHasChanged();
        }

        protected async Task OnDeleteConfirmed(bool deleteConfiremed)
        {
            if (deleteConfiremed)
            {
                await Http.DeleteAsync("Client/delete-client/" + id);
                clients = await Http.GetFromJsonAsync<ClientDto[]>("client");
            }
        }
        public void ChangeIndex(int toWhat)
        {
                index = toWhat;
        }
    }
}

