using System;
using System.Linq;
using Microsoft.Azure.Documents.Client;
using ServiceCore.Configuration;

namespace ServiceCore.Repository
{
    public abstract class BaseRepository<T> where T : class
    {
        protected readonly DocumentConnectionConfiguration DbConfiguration;
        protected Uri CollectionUri;
        protected DocumentClient DbClient;

        protected BaseRepository(DocumentConnectionConfiguration dbConfiguration)
        {
            DbConfiguration = dbConfiguration;

            Init();
        }

        private void Init()
        {
            DbClient = new DocumentClient(new Uri(DbConfiguration.DocumentDbEndPoint), DbConfiguration.DocumentDbKey);
            DbClient.ReadDatabaseAsync(UriFactory.CreateDatabaseUri(DbConfiguration.DatabaseName)).Wait();

            var collectionInfo =
                DbConfiguration.CollectionDbs.FirstOrDefault(x =>
                    x.Name == typeof(T).Name.ToString().ToLower() + "Collection");
            
            //TODO - Add exception when the result is null

            CollectionUri =
                UriFactory.CreateDocumentCollectionUri(DbConfiguration.DatabaseName, collectionInfo?.Value);
        }
    }
}