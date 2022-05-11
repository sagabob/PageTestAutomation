using System.Collections.Generic;
using AppDomain.PageModels;

namespace PageService
{
    public interface IPageService
    {
        IEnumerable<Page> GetAllPages();
        Page GetPageByAlias(string alias);
        Page GetPageById(int id);

        IEnumerable<Page> GetSelectedPages(int[] ids);
    }
}