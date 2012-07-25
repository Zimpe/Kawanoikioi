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
        private KawanoikioiDbContext _context = new KawanoikioiDbContext();

        public void ProcessRequest(HttpContext context)
        {
            RouteData route = context.Request.RequestContext.RouteData;
            string uploader = route.Values["uploader"].ToString();
            string filename = route.Values["filename"].ToString();
            if (!string.IsNullOrEmpty(uploader) || !string.IsNullOrEmpty(filename))
            {
                Image img = _context.Images.Where(i => i.Uploader == uploader & i.FileName == filename).SingleOrDefault();
                if (img != null)
                {
                    context.Response.ContentType = img.MimeType;
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