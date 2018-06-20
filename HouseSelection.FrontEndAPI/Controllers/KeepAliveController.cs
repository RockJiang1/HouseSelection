using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HouseSelection.Model;
using HouseSelection.BLL;

namespace HouseSelection.FrontEndAPI.Controllers
{
    public class KeepAliveController : ApiController
    {
        private ApplicationBLL _appBLL = new ApplicationBLL();
        public BaseResultEntity Post()
        {
            var ret = new BaseResultEntity()
            {
                Code = 0,
                ErrMsg = ""
            };

            try
            {
                var app = _appBLL.GetModels(x => x.ID == 1).FirstOrDefault();

            }
            catch (Exception ex)
            {

            }
            return ret;
        }
    }
}
