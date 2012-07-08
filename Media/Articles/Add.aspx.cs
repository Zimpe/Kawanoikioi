using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Kawanoikioi.Models;
using System.Web.Routing;

namespace Kawanoikioi.Media.Articles
{
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            KawanoikioiDbRepository _repository = new KawanoikioiDbRepository();

            if (_repository.AddArticle(HttpContext.Current.User.Identity.Name, TitleTextBox.Text, ContentTextBox.Text, false))
            {
                ResultLabel.Text = "The Article was successfully added to our database";
                TitleTextBox.Text = "";
                ContentTextBox.Text = "";

                HttpContext.Current.Response.RedirectToRoute("MediaRoute", new RouteValueDictionary
                {
                    { "media", "Articles" }
                });
            }
            else
            {
                ResultLabel.Text = "The Article was <u>not</u> successfully added to our database";
            }
        }
    }
}