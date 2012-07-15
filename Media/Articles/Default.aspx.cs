using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Routing;

namespace Kawanoikioi.Media.Articles
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ArticlesListingView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HyperLink articleLink = (HyperLink)e.Row.Cells[1].FindControl("ArticleLink");
                Kawanoikioi.Models.Article art = (Kawanoikioi.Models.Article)e.Row.DataItem;
                articleLink.NavigateUrl = Page.GetRouteUrl("MediaRoute", new RouteValueDictionary
                {
                    { "media", "Articles" },
                    { "action", "Show" },
                    { "id", art.UniqueName }
                });
            }
        }
    }
}