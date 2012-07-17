using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Kawanoikioi.Models;

namespace Kawanoikioi.Media.Images
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ImagesList_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            Panel ImagePanel = (Panel)e.Item.FindControl("ImagePanel");
            Label FileNameLabel = (Label)ImagePanel.FindControl("FileNameLabel");
            System.Web.UI.WebControls.Image ShowImage = (System.Web.UI.WebControls.Image)ImagePanel.FindControl("ShowImage");
            Label UploaderLabel = (Label)ImagePanel.FindControl("UploaderLabel");
            Label SubmissionDate = (Label)ImagePanel.FindControl("SubmissionDateLabel");
            Models.Image img = (Models.Image)e.Item.DataItem;

            if (img.FileName.Length >= 13)
            {
                string shortFileName = img.FileName.Substring(0, 13);
                FileNameLabel.Text = shortFileName + "...";
            }
            else
            {
                FileNameLabel.Text = img.FileName;
            }
            FileNameLabel.ToolTip = img.FileName;
            ShowImage.ImageUrl = string.Format("~/Files/{0}/Images/{1}", img.Uploader, img.FileName);
            ShowImage.Width = 100;
            ShowImage.Height = 100;
            ShowImage.AlternateText = img.FileName;            
            UploaderLabel.Text = img.Uploader;
            SubmissionDate.Text = img.SubmissionDate.ToString();
        }
    }
}