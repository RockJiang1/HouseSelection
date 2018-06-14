using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HouseSelection.Model;

namespace HouseSelection.PrivateAPI.Models
{
    public class HDFile : BaseResultEntity
    {
        public HDFile(string name, string url, string size)
        {
            //Name = name;
            //Url = url;
            //Size = size;
            Code = 0;
            ErrMsg = "";
        }

        //public string Name { get; set; }

        //public string Url { get; set; }

        //public string Size { get; set; }
    }
}