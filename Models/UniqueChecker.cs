using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Kawanoikioi.Models
{
    class UniqueChecker
    {
        private KawanoikioiDbContext _context = new KawanoikioiDbContext();
        private string[] supportedTypes = new string[]
        {
            "Articles", 
            "Forums",
            "ForumMessages",
            "Images",
            "Videos"
        };

        public string GetName(string name, string type)
        {
            string originalName = name;

            int tryNumber = 0;
            while (!IsUnique(name, type))
            {
                name = originalName + tryNumber;
            }

            return name;
        }

        private bool IsUnique(string name, string type)
        {
            bool result = true;

            if (type == "Articles")
            {
                List<Article> articles = _context.Articles.Where(a => a.UniqueName == name).ToList();
                if (articles.Count != 0)
                {
                    result = false;
                }
            }

            if (type == "Forums")
            {
                List<Forum> forums = _context.Forums.Where(f => f.Name == name).ToList();
                if (forums.Count != 0)
                {
                    result = false;
                }
            }

            if (type == "ForumMessages")
            {
                List<ForumMessage> forumMessages = _context.ForumMessages.Where(f => f.UniqueName == name).ToList();
                if (forumMessages.Count != 0)
                {
                    result = false;
                }
            }

            if (type == "Images")
            {
                List<Image> img = _context.Images.Where(i => i.FileName == name & i.Uploader == HttpContext.Current.User.Identity.Name).ToList();
                if (img.Count != 0)
                {
                    result = false;
                }
            }

            if (type == "Videos")
            {
                List<Video> vid = _context.Videos.Where(v => v.FileName == name && v.Uploader == HttpContext.Current.User.Identity.Name).ToList();
                if (vid.Count != 0)
                {
                    result = false;
                }
            }

            if (!supportedTypes.Contains(type))
            {
                throw new NotImplementedException("The UniqueChecker-class does not support the specified type.");
            }

            return result;
        }
    }
}
