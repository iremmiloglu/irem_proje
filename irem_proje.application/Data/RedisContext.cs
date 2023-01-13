using irem_proje.application.Data.Base;
using irem_proje.application.Settings.Base;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace irem_proje.application.Data
{
    public class RedisContext : IRedisContext
    {
        public RedisContext(IRedisSettings settings)
        {
            var _redis = ConnectionMultiplexer.Connect(new ConfigurationOptions
            {
                EndPoints = {settings.ConnectionStrings }
            });
            RedisDb = _redis.GetDatabase();
            
        }

        public IDatabase RedisDb { get; set; }
    }
}
