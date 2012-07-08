using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Web.Routing;

namespace Kawanoikioi.Account
{
    public partial class Profile : System.Web.UI.Page
    {
        private MembershipUser currentUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                currentUser = Membership.GetUser(Page.RouteData.Values["id"].ToString());
            }
            catch
            {
                throw new ArgumentNullException("This page requires an username to be specified in the URL to function. Please try correcting the adress by adding a username or if you were lead here from a link on this website please report it as a broken link.");
            }

            PopulateControlsWithData();
        }

        private void PopulateControlsWithData()
        {
            HeaderLabel.Text = currentUser.UserName;
            if (currentUser.IsOnline)
            {
                IsOnlineLabel.Text = "Online";
                IsOnlineLabel.ForeColor = System.Drawing.Color.Green;
            }
            CreationDateLabel.Text = currentUser.CreationDate.ToString();
            LastActivityLabel.Text = currentUser.LastActivityDate.ToString();
        }

        protected void OpenForumPaneButton_Click(object sender, EventArgs e)
        {
            ProfileAccordion.SelectedIndex = 0;
        }
    }
}