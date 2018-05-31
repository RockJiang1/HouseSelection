using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseSelection.Utility
{
    public class BaseHelper
    {
        public string[] SplitString(char splitFlag, string solitStr)
        {
            string[] sArrAy = solitStr.Split(splitFlag);

            return sArrAy;
        }
    }
}
