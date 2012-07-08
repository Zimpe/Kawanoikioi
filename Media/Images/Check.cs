using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web.UI.WebControls;

namespace Kawanoikioi.Media.Images
{
    class Check
    {
        internal bool Validate(Stream stream, Label ResultLabel)
        {
            bool result = true;

            try
            {
                System.Drawing.Image img = System.Drawing.Image.FromStream(stream);
                img.Dispose();
            }
            catch
            {
                ResultLabel.Text = "There was an error when the upload was being processed. The file specified by you seems to not be an image.";
                result = false;
            }

            return result;
        }
    }
}
