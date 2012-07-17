using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Kawanoikioi.Models;
using Kawanoikioi.Sanitizers;
using System.Web.Routing;

namespace Kawanoikioi.Media.Images
{
    public partial class Upload : System.Web.UI.Page
    {
        private Check check = new Check();
        private KawanoikioiDbRepository _rep = new KawanoikioiDbRepository();
        private UniqueChecker _unique = new UniqueChecker();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            if (ImageUpload.HasFile & ImageUpload.PostedFile != null)
            {
                if (check.Validate(ImageUpload.PostedFile.InputStream, ResultLabel))
                {
                    try
                    {
                        Kawanoikioi.Models.Image img = new Kawanoikioi.Models.Image
                        {
                            FileName = _unique.GetName(Strings.MakeUrlFriendly(ImageUpload.FileName, true), "Images"),
                            FileData = ImageUpload.FileBytes,
                            MimeType = ImageUpload.PostedFile.ContentType,
                            SubmissionDate = DateTime.Now,
                            Uploader = HttpContext.Current.User.Identity.Name
                        };

                        _rep.AddImage(img);
                    }
                    catch
                    {
                        ResultLabel.Text = "Was unable to complete the process of adding the image to the database.";
                    }
                    finally
                    {
                        ResultLabel.Text = "Your Image was successfully added to the database.";
                        ImageUpload.Dispose();

                        HttpContext.Current.Response.RedirectToRoute("MediaRoute", new RouteValueDictionary
                        {
                            { "media", "Images" }
                        });
                    }
                }
            }
        }
    }
}