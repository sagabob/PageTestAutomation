using System;
using ApplicationCore.AppData;
using AutomationSupport.ExtendedModels;
using JetBrains.Annotations;
using OpenQA.Selenium;

namespace AutomationSupport.Extensions
{
    public static class WebDriverExtensionMethods
    {
       
        public static Document Document([NotNull] this IWebDriver driver)
        {
            if (driver == null) throw new ArgumentNullException(nameof(driver));

            return new Document(driver);
        }


        public static HousingPageDocument HousingPageDocument([NotNull] this IWebDriver driver, [NotNull] IPageContext pageContext)
        {
            if (driver == null) throw new ArgumentNullException(nameof(driver));

            return new HousingPageDocument(pageContext, driver);
        }

    }
}