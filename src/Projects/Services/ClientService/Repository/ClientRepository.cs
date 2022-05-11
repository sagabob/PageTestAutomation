using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AppDomain.ClientModels;
using ServiceCore.Configuration;
using ServiceCore.Repository;

namespace ClientService.Repository
{
    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        //TODO 
        //Need to implement the async version
        public ClientRepository(DocumentConnectionConfiguration dbConfiguration) : base(dbConfiguration)
        {
        }

        public IEnumerable<Client> GetAllClients()
        {
            return DbClient.CreateDocumentQuery<Client>(CollectionUri).AsEnumerable();
        }

        public Client GetClientByAlias(string alias)
        {
            return DbClient.CreateDocumentQuery<Client>(CollectionUri).Where(p => p.Alias == alias).AsEnumerable()
                .FirstOrDefault();
        }

        public Client GetClientById(string id)
        {
            return DbClient.CreateDocumentQuery<Client>(CollectionUri)
                .Where(p => p.Id == id).AsEnumerable().FirstOrDefault();
        }

        public Client GetClientWithQuery(Expression<Func<Client, bool>> predicate)
        {
            return DbClient.CreateDocumentQuery<Client>(CollectionUri)
                .Where(predicate).AsEnumerable().FirstOrDefault();
        }
    }
}