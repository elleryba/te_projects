using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldGeography.DAL;

namespace WorldGeography
{
    class Program
    {
        static void Main(string[] args)
        {
            //IConfigurationBuilder builder = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            //IConfigurationRoot configuration = builder.Build();
            //string connectionString = configuration.GetConnectionString("World");


            ICityDAO cityDAO = new CitySqlDAO(@"Server=.\SQLEXPRESS;Database=World;Trusted_Connection=True;");
            ICountryDAO countryDAO = new CountrySqlDAO(@"Server=.\SQLEXPRESS;Database=World;Trusted_Connection=True;");
            ILanguageDAO languageDAO = null;

            WorldGeographyCLI cli = new WorldGeographyCLI(cityDAO, countryDAO, languageDAO);
            cli.RunCLI();
        }
    }
}
