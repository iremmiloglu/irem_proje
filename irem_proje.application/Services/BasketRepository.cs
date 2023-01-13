using irem_proje.application.Data.Base;
using irem_proje.application.Services.Base;
using irem_proje.domain.Models;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace irem_proje.application.Services
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDatabase _context;
        public BasketRepository(IRedisContext context)
        {
            _context = context.RedisDb;
        }
        public List<Basket> GetBaskets(string key)
        {
            List<Basket> response = new List<Basket>();
            string baskets = "";
            if (_context.StringGet(key).HasValue)
            {
                baskets = _context.StringGet(key);
                response = JsonConvert.DeserializeObject<List<Basket>>(baskets);
            }
            return response;
        }

        public bool SaveBasket(List<Basket> basket,string Id)
        {
            if (!string.IsNullOrEmpty(Id))
            {
                string ResultBasket = JsonConvert.SerializeObject(basket);
                return _context.StringSet(Id, ResultBasket);
            }
            else
            {
                return false;
            }
        }
    }
}
