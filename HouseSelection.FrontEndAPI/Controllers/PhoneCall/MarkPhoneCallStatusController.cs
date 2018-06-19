using HouseSelection.BLL;
using HouseSelection.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace HouseSelection.FrontEndAPI.Controllers.PhoneCall
{
    public class MarkPhoneCallStatusController:ApiController
    {
        ShakingNumberResultBLL _shakingNumberResultBLL = new ShakingNumberResultBLL();

        public BaseResultEntity Post()
        {
            var ret = new BaseResultEntity();
            return ret;
        }
    }
}