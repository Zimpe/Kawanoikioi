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
        private KawanoikioiDbContext _context = new KawanoikioiDbContext();
        private Strings _stringSanitizer = new Strings();
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
                        Kawanoikioi.Models.Images img = new Kawanoikioi.Models.Images();
                        img.FileName = _unique.GetName(_stringSanitizer.MakeUrlFriendly(ImageUpload.FileName, true), "Images");
                        img.FileData = ImageUpload.FileBytes;
                        img.MimeType = ImageUpload.PostedFile.ContentType;
                        img.SubmissionDate = DateTime.Now;
                        img.Uploader = HttpContext.Current.User.Identity.Name;

                        _context.Images.Add(img);
                        _context.SaveChanges();
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