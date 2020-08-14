using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldGeography.Models;

namespace WorldGeography.DAL
{
    public class LanguageSqlDAO : ILanguageDAO
    {
        private string connectionString;

        /// <summary>
        /// Creates a sql based language dao.
        /// </summary>
        /// <param name="databaseConnectionString"></param>
        public LanguageSqlDAO(string databaseConnectionString)
        {
            connectionString = databaseConnectionString;
        }

        public IList<Language> GetLanguages(string countryCode)
        {
            throw new NotImplementedException();
        }

        public bool AddNewLanguage(Language newLanguage)
        {
            throw new NotImplementedException();
        }

        public bool RemoveLanguage(Language deadLanguage)
        {
            throw new NotImplementedException();
        }
    }
}
