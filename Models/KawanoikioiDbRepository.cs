using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kawanoikioi.Sanitizers;
using Kawanoikioi.Chat;

namespace Kawanoikioi.Models
{
    public partial class KawanoikioiDbRepository
    {
        #region Private Variables Definition
        private KawanoikioiDbContext _context = new KawanoikioiDbContext();
        private UniqueChecker _unique = new UniqueChecker();
        private bool result = true;
        #endregion

        #region Media
        #region Articles
        public List<Article> GetArticles()
        {
            return _context.Articles.Where(a => a.IsPublished == true).ToList();
        }

        public List<Article> GetArticles(string author)
        {
            return _context.Articles.Where(a => a.Author == author).ToList();
        }

        public Article GetArticle(string uniqueName)
        {
            return _context.Articles.Where(a => a.UniqueName == uniqueName & a.IsPublished == true).SingleOrDefault();
        }

        public bool AddArticle(string author, string name, string content, bool isPublished)
        {
            try
            {
                Article a = new Article();

                a.Author = author;
                a.Content = content;
                a.IsPublished = isPublished;
                a.Name = name;
                a.UniqueName = _unique.GetName(Strings.MakeUrlFriendly(name), "Articles");
                a.SubmissionDate = DateTime.Now;
                a.LastModified = DateTime.Now;

                _context.Articles.Add(a);
                _context.SaveChanges();
            }
            catch
            {
                result = false;
            }
            return result;
        }
        #endregion

        #region Images
        public List<Image> GetImages()
        {
            return _context.Images.ToList();
        }

        public List<Image> GetImages(string uploader)
        {
            return _context.Images.Where(i => i.Uploader == uploader).ToList();
        }

        public void AddImage(Image img)
        {
            _context.Images.Add(img);
            _context.SaveChanges();
        }
        #endregion

        #region Videos
        public List<Video> GetVideos()
        {
            return _context.Videos.ToList();
        }

        public List<Video> GetVideos(string uploader)
        {
            return _context.Videos.Where(v => v.Uploader == uploader).ToList();
        }

        public Video GetVideo(string uploader, string filename)
        {
            return _context.Videos.Where(v => v.Uploader == uploader & v.FileName == filename).SingleOrDefault();
        }
        public void AddVideo(Video v)
        {
            _context.Videos.Add(v);
            _context.SaveChanges();
        }
        #endregion
        #endregion

        #region Community
        #region Forum
        public List<ForumCategory> GetForumCategories()
        {
            return _context.ForumCategories.OrderBy(f => f.OrderID).ToList();
        }

        public List<Forum> GetForums(int categoryID)
        {
            return _context.Forums.Where(f => f.CategoryID == categoryID).OrderBy(f => f.OrderID).ToList();
        }

        public List<ForumMessage> GetForumMessages(string uniqueName)
        {
            return _context.ForumMessages.Where(f => f.ForumID == uniqueName & f.IsReply == false).ToList();
        }

        public List<ForumMessage> GetForumMessagesByUser(string author)
        {
            return _context.ForumMessages.Where(f => f.Author == author & f.IsReply == false).ToList();
        }

        public ForumMessage GetForumMessage(string uniqueName)
        {
            return _context.ForumMessages.Where(f => f.UniqueName == uniqueName & f.IsReply == false).SingleOrDefault();
        }

        public List<ForumMessage> GetForumReplies(string uniqueName)
        {
            return _context.ForumMessages.Where(f => f.UniqueName == uniqueName & f.IsReply == true).ToList();
        }

        public bool AddForumMessage(string name, string content, string author, bool isReply, string forumID, string replyTo = null)
        {
            try
            {
                ForumMessage forumMessage = new ForumMessage();

                forumMessage.Author = author;
                forumMessage.Content = content;
                forumMessage.ForumID = forumID;
                forumMessage.IsReply = isReply;
                forumMessage.ReplyTo = replyTo;
                forumMessage.SubmissionDate = DateTime.Now;
                forumMessage.LastModified = DateTime.Now;
                forumMessage.Name = name;
                forumMessage.UniqueName = _unique.GetName(Strings.MakeUrlFriendly(name), "ForumMessages");

                _context.ForumMessages.Add(forumMessage);
                _context.SaveChanges();
            }
            catch
            {
                result = false;
            }

            return result;
        }
        #endregion
        #endregion
    }
}