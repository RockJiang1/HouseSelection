using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HouseSelection.PrivateAPI.Models;
using HouseSelection.Model;
using HouseSelection.BLL;
using HouseSelection.LoggerHelper;
using HouseSelection.Authorize;
using HouseSelection.Utility;

namespace HouseSelection.PrivateAPI.Controllers
{
    public class GetProjectByIDController : ApiController
    {
        private ProjectBLL _projectBLL = new ProjectBLL();

        [ApiAuthorize]
        public ProjectResultEntity Post(GetProjectByIDRequestModel ProjectID)
        {
            Logger.LogDebug("GetProjectByID Request:" + JsonHelper.SerializeObject(ProjectID), "GetProjectByIDController", "Post");
            ProjectResultEntity ret = new ProjectResultEntity();
            try
            {
                var _project = _projectBLL.GetModels(x=> x.ID == ProjectID.ProjectID).FirstOrDefault();
                if(_project != null)
                {
                    ret.Project = new ProjectEntity()
                    {
                        ID = _project.ID,
                        Number = _project.Number,
                        Name = _project.Name,
                        Address = _project.Address,
                        ProjectArea = _project.Area.Name,
                        DevelopCompany = _project.DevelopCompany,
                        IdentityNumber = _project.IdentityNumber,
                        IsEnd = _project.IsEnd,
                        EndReason = _project.EndReason
                    };
                    ret.Code = 0;
                    ret.ErrMsg = "";
                }
                else
                {
                    ret.Code = 104;
                    ret.ErrMsg = "查询的项目ID不存在";
                }
                
            }
            catch(Exception ex)
            {
                Logger.LogException("获取项目列表发生异常！", "", "", ex);
                ret.Code = 999;
                ret.ErrMsg = ex.Message;
                ret.Project = null;
            }
            return ret;
        }
    }
}
