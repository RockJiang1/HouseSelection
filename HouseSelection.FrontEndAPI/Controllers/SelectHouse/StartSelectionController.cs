using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HouseSelection.BLL;
using HouseSelection.Model;
using HouseSelection.FrontEndAPI.Models.SelectHouseRequest;
using HouseSelection.LoggerHelper;
using HouseSelection.Authorize;

namespace HouseSelection.FrontEndAPI.Controllers.SelectHouse
{
    public class StartSelectionController : ApiController
    {
        private ShakingNumberResultBLL _shakingBLL = new ShakingNumberResultBLL();
        private SelectingHouseStatusBLL _statusBLL = new SelectingHouseStatusBLL();

        [ApiAuthorize]
        public BaseResultEntity Post(StartSelectionRequestModel req)
        {
            var ret = new BaseResultEntity()
            {
                Code = 0,
                ErrMsg = ""
            };

            try
            {
                var _shaking = _shakingBLL.GetModels(x => x.ID == req.ShakingNumberResultId).FirstOrDefault();
                if(_shaking == null)
                {
                    ret.Code = 401;
                    ret.ErrMsg = "摇号结果ID不存在！";
                }
                else
                {
                    var _dbStatus = new SelectingHouseStatus()
                    {
                        ShakingNumberResultID = req.ShakingNumberResultId,
                        SelectStatus = 1,
                        CreateTime = DateTime.Now,
                        LastUpdate = DateTime.Now
                    };
                    _statusBLL.Add(_dbStatus);
                }
            }
            catch(Exception ex)
            {
                Logger.LogException("开始选房接口发生异常！", "StartSelectionController", "Post", ex);
                ret.Code = 999;
                ret.ErrMsg = ex.Message;
            }
            return ret;
        }
    }
}
