using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace HouseSelection.Utility
{
    public class MD5Helper
    {
        /// <summary>
        /// 将字符串加密成MD5码
        /// </summary>
        /// <param name="text">字符串</param>
        /// <returns></returns>
        public static string ToMD5(string text)
        {
            //转换为UTF8编码  
            byte[] b = System.Text.Encoding.UTF8.GetBytes(text);
            //计算字符串UTF8编码后的MD5哈希值，并转换为字符串  
            MD5 md5 = new MD5CryptoServiceProvider();
            var s = md5.ComputeHash(b);

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < s.Length; i++)
            {
                sb.AppendFormat("{0:x2}", s[i]);
            }
            return sb.ToString();
        }
    }
}
