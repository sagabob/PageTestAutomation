using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AppDomain.ClientModels;

namespace ClientService.Repository
{
    public interface IClientRepository
    {
        IEnumerable<Client> GetAllClients();
        Client GetClientByAlias(string alias);

        Client GetClientById(string id);
        Client GetClientWithQuery(Expression<Func<Client, bool>> predicate);
    }
}