using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HouseSelection.Model;
using HouseSelection.BLL;
using HouseSelection.LoggerHelper;
using HouseSelection.Utility;
using HouseSelection.Authorize;
using HouseSelection.PrivateAPI.Models;

namespace HouseSelection.PrivateAPI.Controllers
{
    public class CloseProjectController : ApiController
    {
        private ProjectBLL _projectBLL = new ProjectBLL();

        [ApiAuthorize]
        public BaseResultEntity Post(CloseProjectRequestModel req)
        {
            var ret = new BaseResultEntity()
            {
                Code = 0,
                ErrMsg = ""
            };

            try
            {
                var _existProject = _projectBLL.GetModels(x => x.ID == req.ProjectID).FirstOrDefault();
                if (_existProject == null)
                {
                    ret.Code = 104;
                    ret.ErrMsg = "关闭的项目ID不存在！";
                }
                else if (_existProject.IsEnd)
                {
                    ret.Code = 105;
                    ret.ErrMsg = "已经结束的项目不允许再次关闭！";
                }
                else
                {
                    _existProject.LastUpdate = DateTime.Now;
                    _existProject.IsEnd = true;
                    _existProject.EndReason = req.EndReason;
                    _projectBLL.Update(_existProject);
                }
            }
            catch(Exception ex)
            {
                Logger.LogException("关闭项目时发生异常！", "CloseProjectController", "Post", ex);
                ret.Code = 999;
                ret.ErrMsg = ex.Message;
            }
            return ret;
        }
    }
}
