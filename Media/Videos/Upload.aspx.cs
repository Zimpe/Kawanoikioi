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
        private FileInfo encodedFile;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            if (VideoFileUpload.HasFile & VideoFileUpload.PostedFile != null)
            {
                if (!tempDir.Exists)
                {
                    tempDir.Create();
                }
                VideoFileUpload.PostedFile.SaveAs(string.Format("{0}\\{1}", tempDir.FullName, VideoFileUpload.FileName));
                Encode(string.Format("{0}\\{1}", tempDir, VideoFileUpload.FileName), VideoFileUpload.FileName);
                Video v = new Video
                {
                    FileName = new UniqueChecker().GetName(Strings.MakeUrlFriendly(VideoFileUpload.FileName), "Videos"),
                    SubmissionDate = DateTime.Now,
                    Uploader = HttpContext.Current.User.Identity.Name
                };
                if (TitleTextBox.Text != null)
                {
                    v.Title = TitleTextBox.Text;
                }
                else
                {
                    string[] fileNameFrags = TitleTextBox.Text.Split('.');
                    v.Title = fileNameFrags[0];
                }
                if (DescriptionTextBox.Text != null)
                {
                    v.Description = DescriptionTextBox.Text;
                }
                encodedFile.Open(FileMode.Open, FileAccess.Read, FileShare.Read).Read(v.FileData, 0, (int)encodedFile.Length);
                tempDir.Delete();
                _rep.AddVideo(v);
            }
        }

        private void Encode(string tempPath, string fileName)
        {
            Job job = new Job();
            try
            {
                MediaItem item = new MediaItem(tempPath);
                job.MediaItems.Add(item);
                job.OutputDirectory = string.Format("{0}\\Output", tempDir.FullName);
                job.CreateSubfolder = false;
                job.Encode();
                job.EncodeProgress += new EventHandler<EncodeProgressEventArgs>(job_EncodeProgress);
            }
            catch (EncodeErrorException ex)
            {
                ProgressLabel.Text = ex.Message;
            }
            finally
            {
                Compress(new DirectoryInfo(job.ActualOutputDirectory));
                File.Delete(tempPath);
                encodedFile = new FileInfo(job.ActualOutputDirectory);
                job.CancelEncode();
                job.Dispose();
            }
        }

        private void Compress(DirectoryInfo directoryInfo)
        {
            List<FileInfo> files = new List<FileInfo>(directoryInfo.GetFiles());
            FileStream outFile = File.Create(string.Format("{0}\\CompressedTemp.gz", directoryInfo.FullName));
            GZipStream zipStream = new GZipStream(outFile, CompressionMode.Compress);
            files.ForEach(f=>
            {
                FileStream inFile = f.Open(FileMode.Open, FileAccess.Read, FileShare.Read);
                inFile.CopyTo(zipStream);
            });
        }

        void job_EncodeProgress(object sender, EncodeProgressEventArgs e)
        {
            ProgressLabel.Text = string.Format("Encoding Progress: {0}%", e.Progress);
        }
    }
}