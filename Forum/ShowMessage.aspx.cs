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
    public partial class ShowMessage : System.Web.UI.Page
    {
        private KawanoikioiDbRepository _repository = new KawanoikioiDbRepository();
        private ForumMessage originalMessage = new ForumMessage();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                ReplyPanel.Visible = true;
            }

            try
            {
                originalMessage = _repository.GetForumMessage(Page.RouteData.Values["id"].ToString());
                ReplyHeader.Text = "Write a reply to " + originalMessage.Name;
                TitleTextBox.Text = "Re: " + originalMessage.Name;

                if (ReplyListView.Items.Count > 10)
                {
                    ReplyPager.Visible = true;
                }
            }
            catch
            {
                throw new NullReferenceException("A identifier is required for this resource to be able to show its contents. If you were led here by a link provided on this website please report this broken link.");
            }
        }

        protected void ReplyListView_ItemCreated(object sender, ListViewItemEventArgs e)
        {
            FormView ReplyFormView = (FormView)e.Item.FindControl("ReplyFormView");
            ReplyFormView.DataSource = _repository.GetForumReplies(Page.RouteData.Values["id"].ToString());

            if (e.Item.DisplayIndex % 2 == 0)
            {
                ReplyFormView.CssClass = "replyItem";
            }
            else
            {
                ReplyFormView.CssClass = "replyAlternatingItem";
            }
        }

        protected void ReplyButton_Click(object sender, EventArgs e)
        {
            ReplyButton.Enabled = false;

            if(_repository.AddForumMessage(TitleTextBox.Text, ContentTextBox.Text, HttpContext.Current.User.Identity.Name, true, originalMessage.ForumID, originalMessage.UniqueName))
            {
                HttpContext.Current.Response.RedirectToRoute("ForumRoute", new RouteValueDictionary
                {
                    { "action", "ShowMessage" },
                    { "id", originalMessage.UniqueName }
                });
            }
            else
            {
                ResultLabel.Text = "Bummer! It seems that the process of adding your reply to " + originalMessage.Name + " failed. Please try again.";
                ReplyButton.Enabled = true;
            }
        }
    }
}