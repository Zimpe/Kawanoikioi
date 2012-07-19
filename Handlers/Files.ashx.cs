using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kawanoikioi.Models;
using System.Web.Routing;

namespace Kawanoikioi.Handlers
{
    /// <summary>
    /// Summary description for Images.ashx
    /// </summary>
    public class Files : IHttpHandler
    {
        private KawanoikioiDbContext _context = new KawanoikioiDbContext();

        public Files(HttpContext context)
        {
            ProcessRequest(context);
        }

        public void ProcessRequest(HttpContext context)
        {
            RouteData route = context.Request.RequestContext.RouteData;
            string uploader = route.Values["uploader"].ToString();
            string filename = route.Values["filename"].ToString();
            if (!string.IsNullOrEmpty(uploader) || !string.IsNullOrEmpty(filename))
            {
                if (route.Values["type"].ToString() == "Images")
                {
                    ProcessImage(context, uploader, filename);
                }
                if (route.Values["type"].ToString() == "Videos")
                {
                    ProcessVideo(context, uploader, filename);
                }
                else
                {
                    throw new NotImplementedException("The file type specified is not yet supported.");
                }
            }
        }

        private void ProcessImage(HttpContext http, string uploader, string filename)
        {
            Image img = _context.Images.Where(i => i.Uploader == uploader & i.FileName == filename).SingleOrDefault();
            if (img != null)
            {
                http.Response.ContentType = img.MimeType;
                http.Response.OutputStream.Write(img.FileData, 0, img.FileData.Length);
            }
            else
            {
                http.Response.StatusCode = 404;
            }
        }

        private void ProcessVideo(HttpContext http, string uploader, string filename)
        {
            Video vid = _context.Videos.Where(v => v.Uploader == uploader & v.FileName == filename).SingleOrDefault();
            if (vid != null)
            {
                http.Response.ContentType = "application/gzip";
                http.Response.OutputStream.Write(vid.FileData, 0, vid.FileData.Length);
            }
            else
            {
                http.Response.StatusCode = 404;
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