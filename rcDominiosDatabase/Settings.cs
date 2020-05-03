using System.IO;
using Microsoft.Extensions.Configuration;

namespace rcDominiosDatabase
{
    public class Settings
    {
        private static string GetSettings(string key) 
        {
            IConfigurationRoot configuration;
            ConfigurationBuilder builder = new ConfigurationBuilder();

            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            
            configuration = builder.Build();

            return configuration[key];
        }

        public static string GetDbConnectionString()
        {
            return GetSettings("ConnectionStrings:DefaultConnection");
        }
    }
}
