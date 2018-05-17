﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HouseSelection.DAL;
using HouseSelection.Model;

namespace HouseSelection.BLL
{
    public class BackEndAccountBLL : BaseBLL<BackEndAccount>
    {
        public override void SetDAL()
        {
            _dal = new BackEndAccountDAL();
        }
    }
}
