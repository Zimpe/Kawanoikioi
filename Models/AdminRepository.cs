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
        private Strings _stringSanitizer = new Strings();
        private bool result;

        public List<Articles> GetAllArticles()
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

        public List<Forums> GetForums()
        {
            return _context.Forums.ToList();
        }

        public void UpdateArticle(Articles art)
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
                Forums forum = new Forums();
                forum.CategoryID = categoryID;
                forum.Description = description;
                forum.Name = name;
                forum.UniqueName = _unique.GetName(_stringSanitizer.MakeUrlFriendly(name), "Forums");
                forum.OrderID = orderID;

                _context.Forums.Add(forum);
                _context.SaveChanges();
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public void UpdateForum(Forums f)
        {
            throw new NotImplementedException();
        }

        public void CreateForumCategory(string name, int orderID = 0)
        {
            if (orderID == 0)
            {
                orderID = _context.ForumCategories.LastOrDefault().OrderID + 1;
            }

            ForumCategories forumCat = new ForumCategories();
            forumCat.Name = name;
            forumCat.OrderID = orderID;
            _context.ForumCategories.Add(forumCat);
            _context.SaveChanges();
        }

        public void UpdateForumCategory(ForumCategories fc)
        {
            throw new NotImplementedException();
        }
    }
}