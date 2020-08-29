using System.IO;
using Microsoft.Extensions.Configuration;

namespace rcDominiosWeb
{
     public class Settings
    {
        private static string GetSettings(string sectionName, string key) 
        {
            IConfigurationRoot configuration;
            IConfigurationSection section;

            ConfigurationBuilder builder = new ConfigurationBuilder();

            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            
            configuration = builder.Build();

            section = configuration.GetSection(sectionName);

            return section.GetValue<string>(key);
        }

        public static string GetSetting(string key)
        {
            return GetSettings("Settings", key);
        }

        public static string GetConnectionString()
        {
            return GetSettings("ConnectionStrings", "DefaultConnection");
        }

        public static string GetConnectionString(string key)
        {
            return GetSettings("ConnectionStrings", key);
        }
    }
}
