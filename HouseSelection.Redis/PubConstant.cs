using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseSelection.Redis
{
    public class PubConstant
    {
        public static string RedisIP
        {
            get
            {
                string _redisIp = ConfigurationManager.AppSettings["RedisIP"];
                return _redisIp;
            }
        }
        public static string RedisPort
        {
            get
            {
                string _redisPort = ConfigurationManager.AppSettings["RedisPort"];
                return _redisPort;
            }
        }
        public static string RedisPassword
        {
            get
            {
                string _redisPass = ConfigurationManager.AppSettings["RedisPassword"];
                return _redisPass;
            }
        }

        public static int? DBIndex
        {
            get
            {
                int _dbIndex;
                if (int.TryParse(ConfigurationManager.AppSettings["RedisDBIndex"], out _dbIndex))
                {
                    return _dbIndex;
                }
                return null;
            }
        }


    }
}
