using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using HouseSelection.LoggerHelper;

namespace HouseSelection.PrivateAPI.Models
{
    public class WithExtensionMultipartFormDataStreamProvider : MultipartFormDataStreamProvider
    {
        public WithExtensionMultipartFormDataStreamProvider(string rootPath,int bufferSize)
            : base(rootPath, bufferSize)
        {
        }

        public override string GetLocalFileName(System.Net.Http.Headers.HttpContentHeaders headers)
        {
            Logger.LogInfo("Upload File:" + Path.GetFileName(GetValidFileName(headers.ContentDisposition.FileName)).ToString(), "", "");
            //string extension = !string.IsNullOrWhiteSpace(headers.ContentDisposition.FileName) ? Path.GetExtension(GetValidFileName(headers.ContentDisposition.FileName)) : "";
            //return Guid.NewGuid().ToString() + extension;
            return Path.GetFileName(GetValidFileName(headers.ContentDisposition.FileName));
        }

        private string GetValidFileName(string filePath)
        {
            char[] invalids = System.IO.Path.GetInvalidFileNameChars();
            return String.Join("_", filePath.Split(invalids, StringSplitOptions.RemoveEmptyEntries)).TrimEnd('.');
        }
    }
}