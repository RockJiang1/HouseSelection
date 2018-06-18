using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HouseSelection.BLL;
using HouseSelection.FrontEndAPI.Models.SelectHouseRequest;
using HouseSelection.FrontEndAPI.Models.SelectHouseResult;
using HouseSelection.LoggerHelper;
using HouseSelection.Model;
using HouseSelection.Utility;
using HouseSelection.Authorize;

namespace HouseSelection.FrontEndAPI.Controllers.SelectHouse
{
    public class GetHouseEstatesController : ApiController
    {
        HouseEstateBLL _houseEstateBLL = new HouseEstateBLL();
        ShakingNumberResultBLL _shakingBLL = new ShakingNumberResultBLL();

        [ApiAuthorize]
        public GetHouseEstatesResultEntity Post(GetHouseEstatesRequestModel req)
        {
            Logger.LogDebug("GetHousesEstateByProject Request:" + JsonHelper.SerializeObject(req), "GetHouseEstatesByProjectController", "Post");
            GetHouseEstatesResultEntity ret = new GetHouseEstatesResultEntity
            {
                Code = 0,
                ErrMsg = "",
                HouseEstates = new List<HouseEstateEntity>()
            };

            try
            {
                if (req.ShakingNumberResultID > 0)
                {
                    var _shakingResult = _shakingBLL.GetModels(p => p.ID == req.ShakingNumberResultID).FirstOrDefault();

                    if (_shakingResult == null)
                    {
                        throw (new Exception("要好结果【" + req.ShakingNumberResultID + "】不存在！请确认项目信息！"));
                    }

                    var _houseEstates = _houseEstateBLL.GetModels(h => h.ProjectID == _shakingResult.ProjectGroup.ProjectID).ToList();
                    if (_houseEstates != null && _houseEstates.Count > 0)
                    {
                        _houseEstates.ForEach(h =>
                        {
                            var houseEstate = new HouseEstateEntity()
                            {
                                HouseEstateID = h.ID,
                                HouseEstateName = h.Name,
                                ProjectName = _shakingResult.ProjectGroup.Project.Name,
                                ProjectNumber = _shakingResult.ProjectGroup.Project.Number
                            };
                            ret.HouseEstates.Add(houseEstate);
                        });
                    }
                }
                else
                {
                    Logger.LogWarning("摇号ID" + req.ShakingNumberResultID + "无效，请校验后重新请求。", "GetHouseEstatesByProjectController", "post");
                    ret.Code = 2;
                    ret.ErrMsg = "参数错误。";
                }
            }
            catch (Exception ex)
            {
                Logger.LogException("获取楼盘列表时发生异常！", "GetHouseEstatesByProjectController", "Post", ex);
                ret.Code = 999;
                ret.ErrMsg = ex.Message;
            }

            return ret;
        }
    }
}
