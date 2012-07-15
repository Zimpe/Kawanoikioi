using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            "Images"
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
                List<Article> articles = (from a in _context.Articles
                                           where a.UniqueName == name
                                           select a).ToList();
                if (articles.Count != 0)
                {
                    result = false;
                }
            }

            if (type == "Forums")
            {
                List<Forum> forums = (from f in _context.Forums
                                       where f.UniqueName == name
                                       select f).ToList();
                if (forums.Count != 0)
                {
                    result = false;
                }
            }

            if (type == "ForumMessages")
            {
                List<ForumMessage> forumMessages = (from f in _context.ForumMessages
                                                     where f.UniqueName == name
                                                     select f).ToList();
                if (forumMessages.Count != 0)
                {
                    result = false;
                }
            }

            if (type == "Images")
            {
                List<Image> img = (from i in _context.Images
                                    where i.FileName == name
                                    select i).ToList();
                if (img.Count != 0)
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
