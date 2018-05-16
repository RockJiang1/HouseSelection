using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HouseSelection.Model;
using HouseSelection.BLL;
using HouseSelection.LoggerHelper;

namespace HouseSelection.PrivateAPI.Controllers
{
    public class GetProjectByIDController : ApiController
    {
        private ProjectBLL _projectBLL = new ProjectBLL();
        public ProjectResultEntity Get(int ProjectID)
        {
            ProjectResultEntity ret = new ProjectResultEntity();
            try
            {
                var _project = _projectBLL.GetModels(x=> x.ID == ProjectID).FirstOrDefault();
                ret.Project = new ProjectEntity()
                {
                    ID = _project.ID,
                    Number = _project.Number,
                    Name = _project.Name,
                    Address = _project.Address
                };
                ret.code = 0;
                ret.errMsg = "";
            }
            catch(Exception ex)
            {
                Logger.LogException("获取项目列表发生异常！", "", "", ex);
                ret.code = 999;
                ret.errMsg = ex.Message;
                ret.Project = null;
            }
            return ret;
        }
    }
}
