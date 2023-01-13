using irem_proje.application.Data.Base;
using irem_proje.application.Settings.Base;
using irem_proje.domain.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace irem_proje.application.Data
{
    public class CaseContext : ICaseContext
    {
        public CaseContext(ICaseDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionStrings);
            var database = client.GetDatabase(settings.DatabaseName);

            Products = database.GetCollection<Product>("products");
        }
        public IMongoCollection<Product> Products { get; set; }
    }
}
