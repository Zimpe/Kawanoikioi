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
    public class Images : IHttpHandler
    {
        private KawanoikioiDbContext _cont = new KawanoikioiDbContext();

        public void ProcessRequest(HttpContext context)
        {
            string uploader = context.Request.RequestContext.RouteData.Values["uploader"].ToString();
            string filename = context.Request.RequestContext.RouteData.Values["filename"].ToString();
            if (!string.IsNullOrEmpty(uploader) || !string.IsNullOrEmpty(filename))
            {
                Models.Images img = _cont.Images.Where(i => i.Uploader == uploader & i.FileName == filename).SingleOrDefault();
                if (img != null)
                {
                    context.Response.ContentType = img.MimeType;
                    context.Response.Expires = 10;
                    context.Response.OutputStream.Write(img.FileData, 0, img.FileData.Length);
                }
                else
                {
                    context.Response.StatusCode = 404;
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