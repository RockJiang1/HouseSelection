using HouseSelection.BLL;
using HouseSelection.FrontEndAPI.Models.PhoneCallRequest;
using HouseSelection.FrontEndAPI.Models.PhoneCallResult;
using HouseSelection.LoggerHelper;
using HouseSelection.Model;
using HouseSelection.Utility;
using HouseSelection.Authorize;
using HouseSelection.Enum;
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
            Logger.LogInfo("PhoneCallLogin Request:" + JsonHelper.SerializeObject(req), "PhoneCallLoginController", "Post");
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
                //var md5Password = MD5Helper.ToMD5(req.LoginPassword);
                var accountInfo = _accountBLL.GetModels(i => i.Account == req.LoginAccount && i.Password == req.LoginPassword).FirstOrDefault();
                if (accountInfo == null)
                {
                    ret.Code = 101;
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

                    //3.生成Token
                    var result = new TokenResultEntity();

                    var requestAccount = req.LoginAccount;
                    var requestUserId = accountInfo.ID;

                    int expiry = 3600;

                    var token = AuthorizeHelper.AddToken(requestUserId, requestAccount, expiry);

                    if (token != null)
                    {
                        result.Code = (int)InterfaceResultEnum.Success;
                        result.Access_Token = token.AccessToken;
                        result.Refresh_Token = token.RefreshToken;
                        result.Expiry = token.Expiry;
                        Logger.LogInfo(string.Format("获取Token成功，AppId:{0},AppSecret:{1},AccessToken:{2}", req.LoginAccount, req.LoginPassword, token.AccessToken), "TokenController", "Post");
                    }
                    else
                    {
                        ret.Code = (int)InterfaceResultEnum.AppError;
                        ret.ErrMsg = EnumHelper.GetDescription(InterfaceResultEnum.AppError);
                        Logger.LogInfo(string.Format("获取Token失败，AppId:{0},AppSecret:{1}", req.LoginAccount, req.LoginPassword), "TokenController", "Post");
                    }
                    ret.Token = result;
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