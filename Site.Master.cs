using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Kawanoikioi
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Properties.Settings.Default.SiteName))
            {
                throw new NullReferenceException("It seems that a site name for this application has not been specified. Á sitename is required by this application. If you are an administrator of this application please verify that a Site Name is specified in the Default Application Settings-file is set.");
            }
            else
            {
                Page.Title = Properties.Settings.Default.SiteName;

                if (string.IsNullOrEmpty(Properties.Settings.Default.LogoUrl))
                {
                    Label HeaderLabel = new Label();
                    HeaderLabel.Text = Properties.Settings.Default.SiteName;
                    HeaderLabel.SkinID = "HeaderLabel";
                    HeaderPlaceHolder.Controls.Add(HeaderLabel);
                }
                else
                {
                    Image HeaderLogo = new Image();
                    HeaderLogo.AlternateText = "Logotype for " + Properties.Settings.Default.SiteName + ".";
                    HeaderLogo.ImageUrl = Properties.Settings.Default.LogoUrl;
                    HeaderLogo.SkinID = "LogoHeader";
                    HeaderPlaceHolder.Controls.Add(HeaderLogo);
                }
            }
        }
    }
}
