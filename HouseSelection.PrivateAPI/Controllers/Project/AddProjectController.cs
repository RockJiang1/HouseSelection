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

namespace HouseSelection.PrivateAPI.Controllers
{
    public class AddProjectController : ApiController
    {
        private ProjectBLL _projectBLL = new ProjectBLL();
        private AreaBLL _areaBLL = new AreaBLL();

        public BaseResultEntity Post(ProjectEntity Project)
        {
            Logger.LogDebug("AddProject Request:" + JsonHelper.SerializeObject(Project), "AddProjectController", "Post");
            BaseResultEntity ret = new BaseResultEntity();
            try
            {
                var _existProject = _projectBLL.GetModels(x => x.Number == Project.Number || x.Name == Project.Name).ToList();
                if (_existProject == null || _existProject.Count() == 0)
                {
                    var _area = _areaBLL.GetModels(x => x.Name == Project.ProjectArea).FirstOrDefault();
                    if (_area != null && _area.ID != 0)
                    {
                        if (!string.IsNullOrWhiteSpace(Project.Number) && !string.IsNullOrWhiteSpace(Project.Name))
                        {
                            var _newProject = new Project()
                            {
                                Number = Project.Number,
                                Name = Project.Name,
                                //Address = Project.Address,
                                Address = "",
                                AreaID = _area.ID,
                                DevelopCompany = Project.DevelopCompany,
                                IdentityNumber = Project.IdentityNumber,
                                CreateTime = DateTime.Now,
                                LastUpdate = DateTime.Now,
                                IsEnd = false,
                                EndReason = null
                            };
                            _projectBLL.Add(_newProject);
                            ret.Code = 0;
                            ret.ErrMsg = "";
                        }
                        else
                        {
                            ret.Code = 102;
                            ret.ErrMsg = "创建项目的编号/名称不允许为空！";
                        }
                    }
                    else
                    {
                        ret.Code = 103;
                        ret.ErrMsg = "项目所属区域不存在！";
                    }
                }
                else
                {
                    ret.Code = 101;
                    ret.ErrMsg = "创建项目的编号/名称已经存在！";
                }
            }
            catch (Exception ex)
            {
                Logger.LogException("创建项目发生异常！", "AddProjectController", "Post", ex);
                ret.Code = 999;
                ret.ErrMsg = ex.Message;
            }
            return ret;
        }
    }
}
