using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Configuration;
using HouseSelection.PrivateAPI.Models;
using HouseSelection.Authorize;
using HouseSelection.LoggerHelper;
using System.IO;
using System.Threading.Tasks;

namespace HouseSelection.PrivateAPI.Controllers.Files
{
    public class UploadImageController : ApiController
    {
        private string UploadFolder = ConfigurationManager.AppSettings["FilePath"].ToString() + "Image" + "\\";

        [ApiAuthorize]
        public Task<IQueryable<HDFile>> Post()
        {
            try
            {
                string uploadFolderPath = UploadFolder + System.Web.HttpContext.Current.Request["ProjectID"] + "\\";
                Logger.LogDebug("Save Path: " + uploadFolderPath, "UploadImageController", "Post");

                //如果路径不存在，创建路径
                if (!Directory.Exists(uploadFolderPath))
                    Directory.CreateDirectory(uploadFolderPath);

                if (Request.Content.IsMimeMultipartContent())
                {
                    var streamProvider = new WithExtensionMultipartFormDataStreamProvider(uploadFolderPath, 4096);
                    var Task = Request.Content.ReadAsMultipartAsync(streamProvider).ContinueWith(t =>
                    {
                        if (t.IsFaulted || t.IsCanceled)
                        {
                            throw new HttpResponseException(HttpStatusCode.InternalServerError);
                        }

                        var fileInfo = streamProvider.FileData.Select(i =>
                        {
                            var info = new FileInfo(i.LocalFileName);
                            return new HDFile(info.Name, string.Format("{0}?filename={1}", Request.RequestUri.AbsoluteUri, info.Name), (info.Length / 1024).ToString());
                        });
                        return fileInfo.AsQueryable();
                    });

                    return Task;
                }
                else
                {
                    throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotAcceptable, "This request is not properly formatted"));
                }
            }
            catch (Exception ex)
            {
                Logger.LogException("上传图片时发生异常！", "UploadImageController", "Post", ex);
                return null;
            }
        }
    }
}
