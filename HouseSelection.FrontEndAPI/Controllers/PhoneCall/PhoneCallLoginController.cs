using HouseSelection.BLL;
using HouseSelection.FrontEndAPI.Models.PhoneCallRequest;
using HouseSelection.FrontEndAPI.Models.PhoneCallResult;
using HouseSelection.LoggerHelper;
using HouseSelection.Model;
using HouseSelection.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace HouseSelection.FrontEndAPI.Controllers.PhoneCall
{
    public class PhoneCallLoginController : ApiController
    {
        FrontEndAccountBLL _accountBLL = new FrontEndAccountBLL();
        FrontEndAccountLoginRecordBLL _loginRecordBLL = new FrontEndAccountLoginRecordBLL();
        FrontEndAccountProjectMappingBLL _mappingBLL = new FrontEndAccountProjectMappingBLL();
        ProjectBLL _projectBLL = new ProjectBLL();

        public PhoneCallLoginResultEntity Post(PhoneCallLoginRequestModel req)
        {
            var ret = new PhoneCallLoginResultEntity()
            {
                Code = 0,
                ErrMsg = string.Empty,
                AcountProjectInfo = new Model.FrontEndAccountEntity()
                {
                    ProjectList = new List<AccountProjectEntity>()
                }
            };

            try
            {
                var md5Password = MD5Helper.ToMD5(req.LoginPassword);
                var accountInfo = _accountBLL.GetModels(i => i.Account == req.LoginAccount && i.Password == md5Password).FirstOrDefault();
                if (accountInfo == null)
                {
                    ret.ErrMsg = "登陆失败！账号密码错误";
                }
                else
                {
                    var xxx = HttpContext.Current.Request;
                    // 1.保存登陆记录
                    ret.AcountProjectInfo.Account = accountInfo.Account;
                    ret.AcountProjectInfo.AccountID = accountInfo.ID;
                    var loginRecord = new FrontEndAccountLoginRecord()
                    {
                        FrontEndAccountID = accountInfo.ID,
                        LoginTime = DateTime.Now,
                        LoginIP = HttpContext.Current.Request.UserHostAddress
                    };
                    _loginRecordBLL.Add(loginRecord);

                    // 2.获取项目匹配关系，并获取对应项目信息
                    var mappingProjectIds = _mappingBLL.GetModels(i => i.FrontEndAccountID == accountInfo.ID).Select(i => i.ProjectID).ToList();
                    foreach (var projectId in mappingProjectIds)
                    {
                        var projectInfo = _projectBLL.GetModels(i => i.ID == projectId).FirstOrDefault();
                        if (projectInfo != null)
                        {
                            ret.AcountProjectInfo.ProjectList.Add(new AccountProjectEntity()
                            {
                                ProjectID = projectInfo.ID,
                                ProjectName = projectInfo.Name,
                                ProjectNumber = projectInfo.Number,
                                IsEnd = projectInfo.IsEnd,
                                EndReason = projectInfo.EndReason
                            });
                        }
                        else
                        {
                            ret.ErrMsg = ret.ErrMsg + "/n" + string.Format("项目{0}没有查询到对应的项目信息，请核对数据。", projectId);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogException("前台登陆时发生异常！", "PhoneCallLoginController", "Post", ex);
                ret.Code = 999;
                ret.ErrMsg = ex.Message;
            }

            return ret;
        }
    }
}