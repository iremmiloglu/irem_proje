using irem_proje.application.Data.Base;
using irem_proje.application.Services.Base;
using irem_proje.domain.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace irem_proje.application.Services
{
    public class Repository : IRepository
    {
        private readonly ICaseContext _context;
        public Repository(ICaseContext context)
        {
            _context = context;
        }
        public List<Product> GetProducts()
        {
            List<Product> products = _context.Products.Find(i => true).ToList();
            return products;
        }
    }
}
