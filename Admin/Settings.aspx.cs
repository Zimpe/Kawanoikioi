using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Kawanoikioi.Admin
{
    public partial class Settings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LogoSourceSelectionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LogoSourceSelectionList.SelectedValue == "Computer")
            {
                Label LogoLabel = new Label();
                Label BreakLine = new Label();
                FileUpload LogotypeFileUpload = new FileUpload();
                BreakLine.Text = "<br />";
                LogoLabel.Text = "Please select an image from your computer:";
                LogotypePlaceHolder.Controls.Add(LogoLabel);
                LogotypePlaceHolder.Controls.Add(BreakLine);
                LogotypePlaceHolder.Controls.Add(LogotypeFileUpload);
            }
            if (LogoSourceSelectionList.SelectedValue == "Internet")
            {
                Label LogoLabel = new Label();
                Label BreakLine = new Label();
                TextBox LogoUrlTextBox = new TextBox();
                BreakLine.Text = "<br />";
                LogoLabel.Text = "Please specify the URL to the location of your logotype. Please make sure to specify an absolute path such as: http://www.something.com/image.png";
                LogoUrlTextBox.Text = "http://";
                LogotypePlaceHolder.Controls.Add(LogoLabel);
                LogotypePlaceHolder.Controls.Add(BreakLine);
                LogotypePlaceHolder.Controls.Add(LogoUrlTextBox);
            }
        }

        protected void SubmitChangesButton_Click(object sender, EventArgs e)
        {
        }
    }
}