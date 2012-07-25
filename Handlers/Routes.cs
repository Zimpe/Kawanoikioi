using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Kawanoikioi.Handlers
{
    public class Routes : IRouteHandler
    {
        private IHttpHandler handler;

        public IHttpHandler GetHttpHandler(RequestContext request)
        {
                if (!string.IsNullOrEmpty(request.RouteData.Values["fileName"].ToString()))
                {
                    if (request.RouteData.Values["type"].ToString() == "Images")
                    {
                        handler = new Images();
                    }
                    if (request.RouteData.Values["type"].ToString() == "Videos")
                    {
                        handler = new SmoothStreaming();
                    }
                }
                else
                {
                    throw new NotImplementedException("This feature is not yet implemented in the system. Please try again another time.");
                }

            return handler;
        }
    }
}