using WBizTrip.Domain.DTO;

namespace WBizTrip.Client.Services.Abstractions
{
    public interface IClientService
    {
        public Task<List<ClientDto>> GetClients();

        public Task<List<ClientDto>> GetClientFromTeamLeaderId(int TeamLeaderId);
    }
}
