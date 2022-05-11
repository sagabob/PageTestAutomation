using System;
using Microsoft.Extensions.Configuration;

namespace ApplicationCore.AppData
{
    public class AppConfigurationHandler<T>
    {
        public static T GetConfig(string filename, string sectionName)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile(filename, false, true)
                .Build();

            return config.GetSection(sectionName).Get<T>();
        }
    }
}