using System.Collections.Generic;
using AppDomain.PageModels;

namespace PageService.Repository
{
    public interface IPageRepository
    {
        IEnumerable<Page> GetAllPages();

        Page GetPageByAlias(string alias);

        Page GetPageById(int id);
    }
}