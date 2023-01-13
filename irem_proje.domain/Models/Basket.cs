using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace irem_proje.domain.Models
{
    public class Basket
    {
        public string Id { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string ProductId { get; set; }

    }
}
