using System;
using System.Linq;
using ClientService.Repository;

namespace IdPageConsoleTest
{
    public class ClientTest
    {
        private readonly IClientRepository _clientRepository;

        public ClientTest(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public void GetClientByAlias(string alias)
        {
           
            var outputClient = _clientRepository.GetClientByAlias(alias);

            Console.WriteLine($"Client with {alias}: {outputClient?.Name} {outputClient?.Pages.ElementAt(0).Alias}");
        }
    }
}