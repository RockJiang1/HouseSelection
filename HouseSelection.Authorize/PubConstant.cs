using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace HouseSelection.Authorize
{
    public class PubConstant
    {
        private static string _redisAuthDBIndex = "RedisAuthDBIndex";
        private static int _dbIndex = -1;

        public static int? DBIndex
        {
            get
            {
                if (_dbIndex != -1)
                    return _dbIndex;

                if (int.TryParse(ConfigurationManager.AppSettings[_redisAuthDBIndex], out _dbIndex))
                {
                    return _dbIndex;
                }

                return null;
            }
        }
    }
}
