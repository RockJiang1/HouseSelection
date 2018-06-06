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

namespace HouseSelection.PrivateAPI.Controllers
{
    public class EditProjectController : ApiController
    {
        private ProjectBLL _projectBLL = new ProjectBLL();
        private AreaBLL _areaBLL = new AreaBLL();

        [ApiAuthorize]
        public BaseResultEntity Post(ProjectEntity req)
        {
            var ret = new BaseResultEntity()
            {
                Code = 0,
                ErrMsg = ""
            };

            try
            {
                var _existProject = _projectBLL.GetModels(x => x.ID == req.ID).FirstOrDefault();
                if (_existProject == null)
                {
                    ret.Code = 104;
                    ret.ErrMsg = "修改项目的ID不存在！";
                }
                else if (_existProject.IsEnd)
                {
                    ret.Code = 105;
                    ret.ErrMsg = "已经结束的项目不允许修改！";
                }
                else
                {
                    if(_projectBLL.GetModels(x => (x.Number == req.Number || x.Name == req.Name) && x.ID != req.ID).FirstOrDefault() != null)
                    {
                        ret.Code = 106;
                        ret.ErrMsg = "修改项目的编号/名称已经存在！";
                    }
                    else
                    {
                        var _area = _areaBLL.GetModels(x => x.Name == req.ProjectArea).FirstOrDefault();
                        if (_area != null && _area.ID != 0)
                        {
                            if (!string.IsNullOrWhiteSpace(req.Number) && !string.IsNullOrWhiteSpace(req.Name))
                            {
                                _existProject.Number = req.Number;
                                _existProject.Name = req.Name;
                                _existProject.Address = "";
                                _existProject.AreaID = _area.ID;
                                _existProject.DevelopCompany = req.DevelopCompany;
                                _existProject.IdentityNumber = req.IdentityNumber;
                                _existProject.LastUpdate = DateTime.Now;
                                _existProject.IsEnd = false;
                                _existProject.EndReason = null;
                                _projectBLL.Update(_existProject);
                            }
                            else
                            {
                                ret.Code = 102;
                                ret.ErrMsg = "修改项目的编号/名称不允许为空！";
                            }
                        }
                        else
                        {
                            ret.Code = 103;
                            ret.ErrMsg = "项目所属区域不存在！";
                        }
                    }
                    
                }
            }
            catch(Exception ex)
            {
                Logger.LogException("修改项目时发生异常！", "EditProjectController", "Post", ex);
                ret.Code = 999;
                ret.ErrMsg = ex.Message;
            }
            return ret;
        }
    }
}
