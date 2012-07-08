using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Kawanoikioi.Models;
using System.Web.Routing;

namespace Kawanoikioi.Forum
{
    public partial class ShowForum : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string id = Page.RouteData.Values["id"].ToString();
                AddPostLink.NavigateUrl = Page.GetRouteUrl("ForumRoute", new RouteValueDictionary
                {
                    { "action", "Write" },
                    { "id", id }
                });
            }
            catch
            {
                throw new NullReferenceException("A identifier is required for this resource to be able to show its contents. If you were lead here by a link provided on this website please report this broken link.");
            }
        }

        protected void ForumGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HyperLink MessageLink = (HyperLink)e.Row.FindControl("MessageLink");
                ForumMessages message = (ForumMessages)e.Row.DataItem;
                MessageLink.NavigateUrl = Page.GetRouteUrl("ForumRoute", new RouteValueDictionary
                {
                    { "action", "ShowMessage" },
                    { "id", message.UniqueName }
                });
            }
        }
    }
}