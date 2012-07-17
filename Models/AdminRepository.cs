using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kawanoikioi.Sanitizers;

namespace Kawanoikioi.Models
{
    public class AdminRepository : KawanoikioiDbRepository
    {
        private KawanoikioiDbContext _context = new KawanoikioiDbContext();
        private UniqueChecker _unique = new UniqueChecker();
        private bool result;

        public List<Article> GetAllArticles()
        {
            return _context.Articles.ToList();
        }

        public List<Errors> GetErrors()
        {
            return _context.Errors.ToList();
        }

        public Errors GetError(int id)
        {
            return _context.Errors.Where(e => e.ID == id).SingleOrDefault();
        }

        public List<Forum> GetForums()
        {
            return _context.Forums.ToList();
        }

        public void UpdateArticle(Article art)
        {
            throw new NotImplementedException();
        }

        public bool CreateForum(string name, string description, int categoryID, int orderID = 0)
        {
            result = true;

            try
            {
                if (orderID == 0)
                {
                    orderID = _context.Forums.LastOrDefault().OrderID + 1;
                }
                Forum f = new Forum
                {
                    CategoryID = categoryID,
                    Description = description,
                    Name = name,
                    UniqueName = _unique.GetName(Strings.MakeUrlFriendly(name), "Forums"),
                    OrderID = orderID
                };

                _context.Forums.Add(f);
                _context.SaveChanges();
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public void UpdateForum(Forum f)
        {
            throw new NotImplementedException();
        }

        public void CreateForumCategory(string name, int orderID = 0)
        {
            if (orderID == 0)
            {
                orderID = _context.ForumCategories.LastOrDefault().OrderID + 1;
            }

            ForumCategory forumCat = new ForumCategory
            {
                Name = name,
                OrderID = orderID
            };
            _context.ForumCategories.Add(forumCat);
            _context.SaveChanges();
        }

        public void UpdateForumCategory(ForumCategory fc)
        {
            throw new NotImplementedException();
        }
    }
}