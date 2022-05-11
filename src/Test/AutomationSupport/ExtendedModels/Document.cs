using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

namespace AutomationSupport.ExtendedModels
{
    public enum DocumentReadyState
    {
        Loading,

        Interactive,

        Complete
    }

    public class Document
    {
        public Document([NotNull] IWebDriver driver)
        {
            Driver = driver ?? throw new ArgumentNullException(nameof(driver));
        }

        public DocumentReadyState ReadyState
        {
            get
            {
                var documentReadyState = Driver.ExecuteJavaScript<object>("return document['readyState']; ").ToString();

                return documentReadyState switch
                {
                    "loading" => DocumentReadyState.Loading,
                    "interactive" => DocumentReadyState.Interactive,
                    "complete" => DocumentReadyState.Complete,
                    _ => throw new InvalidEnumArgumentException()
                };
            }
        }

        protected IWebDriver Driver { get; }
    }
}