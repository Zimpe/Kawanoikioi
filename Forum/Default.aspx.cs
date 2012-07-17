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
    public partial class Default : System.Web.UI.Page
    {
        private KawanoikioiDbRepository _repository = new KawanoikioiDbRepository();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CategoryRepeater_ItemCreated(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ForumCategory category = (ForumCategory)e.Item.DataItem;
                Label CategoryHeaderLabel = (Label)e.Item.FindControl("CategoryHeaderLabel");
                CategoryHeaderLabel.Text = category.Name;
                GridView CategoryGridView = (GridView)e.Item.FindControl("CategoryGridView");
                CategoryGridView.DataSource = _repository.GetForums(category.ID);
                CategoryGridView.DataBind();
            }
        }

        protected void CategoryGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HyperLink ForumLink = (HyperLink)e.Row.Cells[1].FindControl("ForumLink");
                Models.Forum currentForum = (Models.Forum)e.Row.DataItem;
                ForumLink.NavigateUrl = Page.GetRouteUrl("ForumRoute", new RouteValueDictionary
                {
                    { "action", "ShowForum" },
                    { "id", currentForum.UniqueName }
                });
                ForumLink.Text = currentForum.Name;
            }
        }
    }
}