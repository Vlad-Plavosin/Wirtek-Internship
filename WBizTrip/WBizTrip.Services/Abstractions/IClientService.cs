using WBizTrip.Domain.DTO;
using WBizTrip.Domain.Model;

namespace WBizTrip.Services.Abstractions
{
    public interface IClientService
    {
        public Task<IEnumerable<Client>> GetClients();
        public void CreateClient(Client client);
        public void UpdateClient(int id, Client client);
        public Task<List<ClientDto>> GetClientFromTeamLeaderId(int TeamLeaderId);
        public void DeleteClient(int id);
        public  Client GetClient(int id);
    }
}
