using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace HouseSelection.Utility
{
    public class UnicodeHelper
    {
        /// <summary>
        /// 中文转unicode（符合js规则的）
        /// </summary>
        /// <returns></returns>
        public static string ToJSUnicode(string str)
        {
            string outStr = "";
            if (!string.IsNullOrEmpty(str))
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if (Regex.IsMatch(str[i].ToString(), @"[\u4e00-\u9fa5]")) { outStr += "\\u" + ((int)str[i]).ToString("x"); }
                    else { outStr += str[i]; }
                }
            }
            return outStr;
        }
    }
}
