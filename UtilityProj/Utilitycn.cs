using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using System.Xml;
using System.Xml.Linq;

namespace UtilityProj
{
    public static class DBPropertyUtil
    {
        private static IConfigurationRoot _configuration;
        static string s = null;
        static DBPropertyUtil()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("D:\\AllDemos\\Hexaware\\HRLibraryEndtoEnd\\UtilityProj\\appsettings.json",
               optional: true, reloadOnChange: true);
            _configuration = builder.Build();
        }
        public static string ReturnCn(string key)
        {
            
            s = _configuration.GetConnectionString("dbCn");
           
            return s;
        }
   }
}

