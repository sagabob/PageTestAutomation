using System.Collections.Generic;
using System.Linq;
using AppDomain.ClientModels;
using ClientService.Repository;

namespace ClientService
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public Client GetClientByAlias(string alias)
        {
            return _clientRepository.GetClientByAlias(alias);
        }

        public Client GetClientById(string id)
        {
            return _clientRepository.GetClientById(id);
        }

        public IEnumerable<Client> GetSelectedClients(string[] ids)
        {
            return ids.Select(id => _clientRepository.GetClientById(id));
        }
    }
}