using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Kawanoikioi.Models;
using Kawanoikioi.Sanitizers;
using Microsoft.Expression.Encoder;
using System.IO.Compression;
using Microsoft.Expression.Encoder.Profiles;

namespace Kawanoikioi.Media.Videos
{
    public partial class Upload : System.Web.UI.Page
    {
        private KawanoikioiDbRepository _rep = new KawanoikioiDbRepository();
        private DirectoryInfo tempDir = new DirectoryInfo(HttpContext.Current.Server.MapPath(string.Format("~/Temp/{0}/Videos", HttpContext.Current.User.Identity.Name)));
        private List<FileInfo> encodedFiles = new List<FileInfo>();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            if (VideoFileUpload.HasFile & VideoFileUpload.PostedFile != null)
            {
                string[] fileNameFrags = VideoFileUpload.FileName.Split('.');
                if (!tempDir.Exists)
                {
                    tempDir.Create();
                }
                VideoFileUpload.PostedFile.SaveAs(string.Format("{0}\\{1}", tempDir.FullName, VideoFileUpload.FileName));
                Encode(string.Format("{0}\\{1}", tempDir.FullName, VideoFileUpload.FileName));
                Video v = new Video();
                FileStream compressedFile = Compress(string.Format("{0}_{1}", fileNameFrags[0], DateTime.Now.ToShortDateString()));
                try
                {
                    v.FileName = new UniqueChecker().GetName(Strings.MakeUrlFriendly(VideoFileUpload.FileName), "Videos");
                    v.FileData = new byte[compressedFile.Length];
                    v.SubmissionDate = DateTime.Now;
                    v.Uploader = HttpContext.Current.User.Identity.Name;
                    if (!string.IsNullOrEmpty(TitleTextBox.Text))
                    {
                        v.Title = TitleTextBox.Text;
                    }
                    else
                    {
                        v.Title = fileNameFrags[0];
                    }
                    if (!string.IsNullOrEmpty(DescriptionTextBox.Text))
                    {
                        v.Description = DescriptionTextBox.Text;
                    }
                    compressedFile.Read(v.FileData, 0, (int)compressedFile.Length);
                }
                finally
                {
                    compressedFile.Close();
                    Directory.Delete(HttpContext.Current.Server.MapPath(string.Format("~/Temp/{0}", HttpContext.Current.User.Identity.Name)), true);
                    _rep.AddVideo(v);
                }
            }
        }

        private void Encode(string tempPath)
        {
            Job job = new Job();
            try
            {
                MediaItem item = new MediaItem(tempPath);
                job.MediaItems.Add(item);
                job.ApplyPreset(Presets.VC1IISSmoothStreamingHD720pVBR);
                job.OutputDirectory = string.Format(tempDir.FullName);
                job.Encode();
            }
            catch (EncodeErrorException ex)
            {
                ProgressLabel.Text = ex.Message;
            }
            finally
            {
                foreach (FileInfo fi in new DirectoryInfo(job.ActualOutputDirectory).GetFiles())
                {
                    encodedFiles.Add(fi);
                }
                job.CancelEncode();
                job.Dispose();
                File.Delete(tempPath);
            }
        }

        private FileStream Compress(string outputFilename)
        {
            string outPath = string.Format("{0}\\{1}.gz", tempDir.FullName, outputFilename);
            FileStream outFile = File.Create(outPath);
            GZipStream zipStream = new GZipStream(outFile, CompressionMode.Compress);
            encodedFiles.ForEach(f =>
            {
                FileStream inFile = f.Open(FileMode.Open, FileAccess.Read, FileShare.Read);
                inFile.CopyTo(zipStream);
                inFile.Close();
            });
            return outFile;
        }
    }
}