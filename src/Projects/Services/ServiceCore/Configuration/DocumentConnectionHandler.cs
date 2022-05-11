using System;
using Microsoft.Extensions.Configuration;

namespace ServiceCore.Configuration
{
    public class DocumentConnectionHandler
    {
        public DocumentConnectionHandler(string filename, string sectionName)
        {
            Filename = filename;
            SectionName = sectionName;
            DbConnectionConfiguration = GetConnectionSettings();
        }

        public string Filename { get; set; }

        public string SectionName { get; set; }

        public DocumentConnectionConfiguration DbConnectionConfiguration { get; set; }

        public DocumentConnectionConfiguration GetConnectionSettings()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile(Filename, false, true)
                .Build();

            return config.GetSection(SectionName).Get<DocumentConnectionConfiguration>();
        }
    }
}