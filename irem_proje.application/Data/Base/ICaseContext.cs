using irem_proje.domain.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace irem_proje.application.Data.Base
{
    public interface ICaseContext
    {
        IMongoCollection<Product> Products { get; set; }

    }
}
