using System;
using System.Collections.Generic;
using System.Linq;
using ApplicationCore.AppData;
using ApplicationCore.Models;
using JetBrains.Annotations;
using OpenQA.Selenium;

namespace AutomationSupport.ExtendedModels
{
    public class HousingPageDocument : Document
    {
        public HousingPageDocument([NotNull] IPageContext pageContext, [NotNull] IWebDriver driver) : base(driver)
        {
            PageContext = pageContext;
        }

        protected IPageContext PageContext { get; }

        public bool IsPageExisted
        {
            get
            {
                if (ReadyState != DocumentReadyState.Complete) return false;

                var pageNotFoundElement =
                    Driver.FindElements(By.XPath($"//*[text()='{PageContext.TestConfig.PageNotFoundMessage}']"));

                return !(pageNotFoundElement.Count > 0);
            }
        }

        public bool IsPageBlank
        {
            get
            {
                var body = Driver.FindElement(By.TagName("body"));
                var subElements =
                    body.FindElements(By.XPath(".//*"));

                return subElements.Count == 0;
            }
        }


        public List<string> FindCollapsibleMenuLinks(IWebElement selectedMenu)
        {
            var urlList = new List<string>();
            try
            {
                var parent = selectedMenu.FindElement(By.XPath("./.."));

                var collapsibleDiv =
                    parent.FindElement(
                        By.ClassName(PageContext.PageModel.MainMenuModel.MenuItemCollapsibleDivClassName));


                var liElements =
                    collapsibleDiv.FindElements(By.ClassName(PageContext.PageModel.MainMenuModel
                        .MenuItemCollapsibleLiClassName));


                urlList.AddRange(liElements.Select(liElement =>
                    liElement.FindElement(By.TagName("a")).GetAttribute("href")));
            }
            catch (Exception)
            {
                // ignored
            }

            return urlList;
        }

        public bool TestAllMenuLinks(List<string> urlList)
        {
            var hasValidSubMenu = true;
            try
            {
                foreach (var selectedUrl in urlList)
                {
                    Driver.Navigate().GoToUrl(selectedUrl);
                   
                    hasValidSubMenu = hasValidSubMenu && IsPageExisted && !IsPageBlank;
                }
            }
            catch (Exception)
            {
                hasValidSubMenu = false;
            }

            return hasValidSubMenu;
        }

        public bool ExpandTestAllMenuItems(List<Menu> menuItems)
        {
            try
            {
                var sidebar = GetSideBar();
                var menuItemButtons =
                    sidebar.FindElements(By.ClassName(PageContext.PageModel.MainMenuModel
                        .MenuItemBtnClassName));

                var allUrls = new List<string>();
                foreach (var inputMenu in menuItems)
                foreach (var menu in menuItemButtons)
                    if (menu.Text.Contains(inputMenu.MenuText))
                        allUrls.AddRange(FindCollapsibleMenuLinks(menu));


                return TestAllMenuLinks(allUrls);
            }
            catch (Exception)
            {
                return false;
            }
        }


        public IWebElement GetSideBar()
        {
            try
            {
                var body = Driver.FindElement(By.TagName("body"));
                var containers =
                    body.FindElements(By.ClassName(PageContext.PageModel.MainMenuModel.MenuParentDivClassName));

                foreach (var container in containers)
                {
                    var sidebars =
                        container.FindElements(By.ClassName(PageContext.PageModel.MainMenuModel.MenuClassName));

                    foreach (var sidebar in sidebars)
                    {
                        var menuItemButtons =
                            sidebar.FindElements(By.ClassName(PageContext.PageModel.MainMenuModel
                                .MenuItemBtnClassName));

                        if (menuItemButtons.Count <= 0) continue;
                        return sidebar;
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }

            return null;
        }

        public bool SideBarHasMenu(List<Menu> menuItems)
        {
            try
            {
                var sidebar = GetSideBar();
                var menuItemButtons =
                    sidebar.FindElements(By.ClassName(PageContext.PageModel.MainMenuModel
                        .MenuItemBtnClassName));

                var numberOfMenuItemsCount = (from inputMenu in menuItems
                    from menu in menuItemButtons
                    where menu.Text.Contains(inputMenu.MenuText)
                    select inputMenu).Count();

                return numberOfMenuItemsCount == menuItems.Count;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}