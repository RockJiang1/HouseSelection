using HouseSelection.Authorize;
using HouseSelection.BLL;
using HouseSelection.FrontEndAPI.Models.PublicityRequest;
using HouseSelection.FrontEndAPI.Models.PublicityResult;
using HouseSelection.LoggerHelper;
using HouseSelection.Model;
using HouseSelection.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace HouseSelection.FrontEndAPI.Controllers.Publicity
{
    public class GetHouseEstatesByProjectController:ApiController
    {
        HouseEstateBLL _houseEstateBLL = new HouseEstateBLL();
        ProjectBLL _projectBLL = new ProjectBLL();
        
        public GetHouseEstatesByProjectResultEntity Post(GetHouseEstatesByProjectRequestModel req)
        {
            Logger.LogDebug("GetHousesEstateByProject Request:" + JsonHelper.SerializeObject(req), "GetHouseEstatesByProjectController", "Post");
            GetHouseEstatesByProjectResultEntity ret = new GetHouseEstatesByProjectResultEntity
            {
                code = 0,
                errMsg = "",
                HouseEstates = new List<HouseEstateEntity>()
            };

            try
            {
                if (req.ProjectId > 0)
                {
                    var project = _projectBLL.GetModels(p => p.ID == req.ProjectId).FirstOrDefault();

                    if (project == null)
                    {
                        throw (new Exception("项目【" + req.ProjectId + "】不存在！请确认项目信息！"));
                    }

                    var _houseEstates = _houseEstateBLL.GetModels(h => h.ProjectID == req.ProjectId).ToList();
                    if (_houseEstates != null && _houseEstates.Count > 0)
                    {
                        _houseEstates.ForEach(h => 
                        {
                            var houseEstate = new HouseEstateEntity()
                            {
                                HouseEstateID = h.ID,
                                HouseEstateName = h.Name,
                                ProjectName = project.Name,
                                ProjectNumber = project.Number
                            };
                            ret.HouseEstates.Add(houseEstate);
                        });
                    }
                }
                else
                {
                    Logger.LogWarning("项目id" + req.ProjectId + "无效，请校验后重新请求。", "GetHouseEstatesByProjectController", "post");
                    ret.code = 2;
                    ret.errMsg = "参数错误。";
                }
            }
            catch (Exception ex)
            {
                Logger.LogException("获取项目列表时发生异常！", "GetHouseEstatesByProjectController", "Post", ex);
                ret.code = 999;
                ret.errMsg = ex.Message;
            }

            return ret;
        }
    }
}