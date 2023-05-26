using Capify.CustomerJourney.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using WBizTrip.API.Data;
using WBizTrip.Domain.DTO;
using WBizTrip.Domain.Model;
using WBizTrip.Services.Abstractions;

namespace WBizTrip.Services
{
    public class ClientService : IClientService
    {
        private readonly HttpClient httpClient;

        private readonly WBizTripDbContext _dbContext;
        public ClientService(WBizTripDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Client>> GetClients()
        {
            return await _dbContext.Clients.Include(c => c.TeamLeader).ThenInclude(tl => tl.User).ToListAsync();
        }

        public Client GetClient(int id)
        {

            var client = _dbContext.Clients.Find(id);
            if (client != null)
            {
                return client;
            }
            else
            {
                throw (new ClientNotFoundException("There is no client with this ID"));
            }

        }
        public void CreateClient(Client client)
        {
            _dbContext.Clients.Add(client);
            _dbContext.SaveChanges();
        }

        public void UpdateClient(int id, Client client)
        {
            var clientToUpdate = _dbContext.Clients.Find(id);
            if (clientToUpdate != null)
            {
                clientToUpdate.Address = client.Address;
                clientToUpdate.PhoneNumber = client.PhoneNumber;
                clientToUpdate.AnnualBudget = client.AnnualBudget;
                clientToUpdate.TeamLeader = client.TeamLeader;
                _dbContext.SaveChanges();
            }
        }

        public async Task<List<ClientDto>> GetClientFromTeamLeaderId (int TeamLeaderId)
        {
            var clients = new List<ClientDto>();
            foreach (var client in _dbContext.Clients)
            {
                if (client.TeamLeaderId == TeamLeaderId)
                {
                    var clientDto = new ClientDto()
                    {
                        Id = client.Id,
                        Name = client.Name,
                        Address = client.Address,
                        PhoneNumber = client.PhoneNumber,
                        AnnualBudget= client.AnnualBudget,
                        TeamLeaderId = TeamLeaderId
                    };
                    clients.Add(clientDto);
                }
            }

            return clients;
        }

        public void DeleteClient(int id)
        {
            var client = _dbContext.Clients.Find(id);
            if (client != null)
            {
                _dbContext.Clients.Remove(client);
                _dbContext.SaveChanges();
            }
        }
    }
}
