﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HouseSelection.Model;
using HouseSelection.DAL;

namespace HouseSelection.BLL
{
    public class ApplicationBLL : BaseBLL<ApplicationAccount>
    {
        public override void SetDAL()
        {
            _dal = new ApplicationDAL();
        }
    }
}
