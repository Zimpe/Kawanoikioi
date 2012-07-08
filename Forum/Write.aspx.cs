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
    public partial class Write : System.Web.UI.Page
    {
        private KawanoikioiDbRepository _repository = new KawanoikioiDbRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(Page.RouteData.Values["id"].ToString()))
            {
                throw new NullReferenceException("A identifier is required for this resource to be able to show its contents. If you were lead here by a link provided on this website please report this broken link.");
            }
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            if (_repository.AddForumMessage(TitleTextBox.Text, ContentTextBox.Text, HttpContext.Current.User.Identity.Name, false, Page.RouteData.Values["id"].ToString()))
            {
                HttpContext.Current.Response.RedirectToRoute("ForumRoute", new RouteValueDictionary
                {
                    { "action", "ShowForum" },
                    { "id", Page.RouteData.Values["id"].ToString() }
                });
            }
        }
    }
}