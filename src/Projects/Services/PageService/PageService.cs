using System.Collections.Generic;
using System.Linq;
using AppDomain.PageModels;
using PageService.Repository;

namespace PageService
{
    public class PageService : IPageService

    {
        private readonly IPageRepository _pageRepository;

        public PageService(IPageRepository pageRepository)
        {
            _pageRepository = pageRepository;
        }

        public IEnumerable<Page> GetAllPages()
        {
            return _pageRepository.GetAllPages();
        }

        public Page GetPageByAlias(string alias)
        {
            return _pageRepository.GetPageByAlias(alias);
        }

        public IEnumerable<Page> GetSelectedPages(int[] ids)
        {
            return ids.Select(id => _pageRepository.GetPageById(id));
        }

        public Page GetPageById(int id)
        {
            return _pageRepository.GetPageById(id);
        }
    }
}