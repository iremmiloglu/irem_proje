using irem_proje.domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace irem_proje.application.Services.Base
{
    public interface IRepository
    {
        List<Product> GetProducts();
    }
}
