using System.Collections.Generic;
using System.Linq;
using AppDomain.PageModels;
using ServiceCore.Configuration;
using ServiceCore.Repository;

namespace PageService.Repository
{
    public class PageRepository : BaseRepository<Page>, IPageRepository
    {
        public PageRepository(DocumentConnectionConfiguration dbConfiguration) : base(dbConfiguration)
        {
        }

        public IEnumerable<Page> GetAllPages()
        {
            return DbClient.CreateDocumentQuery<Page>(CollectionUri).AsEnumerable();
        }

        public Page GetPageByAlias(string alias)
        {
            return DbClient.CreateDocumentQuery<Page>(CollectionUri).Where(p => p.Alias == alias).AsEnumerable()
                .FirstOrDefault();
        }

        public Page GetPageById(int id)
        {
            return DbClient.CreateDocumentQuery<Page>(CollectionUri)
                .Where(p => p.PageId == id).AsEnumerable().FirstOrDefault();
        }
    }
}