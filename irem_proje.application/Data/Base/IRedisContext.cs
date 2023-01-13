using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace irem_proje.application.Data.Base
{
    public interface IRedisContext
    {
        public IDatabase RedisDb { get; set; }
    }
}
