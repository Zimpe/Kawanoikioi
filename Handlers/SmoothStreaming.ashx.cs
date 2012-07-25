using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.Routing;
using Kawanoikioi.Models;
using Ionic.Zip;

namespace Kawanoikioi.Handlers
{
    /// <summary>
    /// Summary description for SmoothStreaming
    /// </summary>
    public class SmoothStreaming : IHttpHandler
    {
        private KawanoikioiDbRepository _rep = new KawanoikioiDbRepository();
        private FileInfo tempFile;
        private const string tempPath = HttpContext.Current.Server.MapPath("~/Temp/Cache/");

        public void ProcessRequest(HttpContext context)
        {
            tempFile = new FileInfo(string.Format("{0}\\SmoothStreamingCache_{1}.zip", tempPath, Guid.NewGuid()));
            RouteData route = context.Request.RequestContext.RouteData;
            Video vid = _rep.GetVideo(route.Values["uploader"].ToString(), route.Values["filename"].ToString());
            using (MemoryStream ms = new MemoryStream())
            {
                ms.Write(vid.FileData, 0, vid.FileData.Length);
                using (ZipFile zip = new ZipFile(tempDir))
                {
                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}