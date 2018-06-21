using HouseSelection.BLL;
using HouseSelection.FrontEndAPI.Models;
using HouseSelection.LoggerHelper;
using HouseSelection.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http;

namespace HouseSelection.FrontEndAPI.Controllers
{
    public class UploadController:ApiController
    {
        ShakingNumberResultBLL _shakingNumberResultBLL = new ShakingNumberResultBLL();


        public BaseResultEntity Post(int ShakingResultId)
        {
            var ret = new BaseResultEntity()
            {
                Code = 0,
                ErrMsg = ""
            };
            try
            {
                var shakingInfo = _shakingNumberResultBLL.GetModels(i => i.ID == ShakingResultId).FirstOrDefault();
                
                var projectId = shakingInfo.ProjectGroup.ProjectID;

                var file = HttpContext.Current.Request.Files["file"];

                var savePath = ConfigurationManager.AppSettings["UploadPath"].ToString() + projectId.ToString()+"\\";
                
                string fileName = file.FileName;
                if (!Directory.Exists(savePath))
                {
                    Directory.CreateDirectory(savePath);
                }

                file.SaveAs(savePath + file.FileName);
            }
            catch (Exception ex)
            {
                Logger.LogException("上传文件时发生异常！", "UploadController", "Post", ex);
                ret.Code = 999;
                ret.ErrMsg = ex.Message;
            }
            

            return ret;
        }
    }
}