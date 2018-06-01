using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseSelection.Utility
{
    public static class DateTimeHelper
    {
        public static long GetUnixTimeStamp(DateTime dt)
        {
            return (dt.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
        }

        public static DateTime GetDateTime(long unixTime)
        {
            if (unixTime <= 0)
            {
                return new DateTime(1970, 1, 1);
            }
            return new DateTime(unixTime * 10000000 + 621355968000000000);
        }

        /// <summary>
        /// 区分时区获取时间
        /// </summary>
        /// <param name="unixTime">Unix时间戳</param>
        /// <param name="UTC">时区，正为东时区，负为西时区</param>
        /// <returns></returns>
        public static DateTime GetUTCDatetime(long unixTime, int UTC)
        {
            return new DateTime(unixTime * 10000000 + Convert.ToDateTime("1970-01-01").AddHours(UTC).Ticks);
        }
    }
}


