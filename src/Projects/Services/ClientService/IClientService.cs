using AppDomain.ClientModels;
using System.Collections.Generic;

namespace ClientService
{
    public interface IClientService
    {
        Client GetClientByAlias(string alias);
        Client GetClientById(string id);
        IEnumerable<Client> GetSelectedClients(string[] ids);
    }
}