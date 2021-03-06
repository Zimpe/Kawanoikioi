﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kawanoikioi.Sanitizers;
using Kawanoikioi.Chat;

namespace Kawanoikioi.Models
{
    public partial class KawanoikioiDbRepository
    {
        private KawanoikioiDbContext _context = new KawanoikioiDbContext();
        private UniqueChecker _unique = new UniqueChecker();
        private Strings _stringsSanitizer = new Strings();
        private bool result = true;

        public List<Articles> GetArticles()
        {
            return _context.Articles.Where(a => a.IsPublished == true).ToList();
        }

        public List<Articles> GetArticles(string author)
        {
            return _context.Articles.Where(a => a.Author == author).ToList();
        }

        public Articles GetArticle(string uniqueName)
        {
            return _context.Articles.Where(a => a.UniqueName == uniqueName & a.IsPublished == true).SingleOrDefault();
        }

        public bool AddArticle(string author, string name, string content, bool isPublished)
        {
            try
            {
                Articles a = new Articles();

                a.Author = author;
                a.Content = content;
                a.IsPublished = isPublished;
                a.Name = name;
                a.UniqueName = _unique.GetName(_stringsSanitizer.MakeUrlFriendly(name), "Articles");
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

        public List<ForumCategories> GetForumCategories()
        {
            return _context.ForumCategories.OrderBy(f => f.OrderID).ToList();
        }

        public List<Forums> GetForums(int categoryID)
        {
            return _context.Forums.Where(f => f.CategoryID == categoryID).OrderBy(f => f.OrderID).ToList();
        }

        public List<ForumMessages> GetForumMessages(string uniqueName)
        {
            return _context.ForumMessages.Where(f => f.ForumID == uniqueName & f.IsReply == false).ToList();
        }

        public List<ForumMessages> GetForumMessagesByUser(string author)
        {
            return _context.ForumMessages.Where(f => f.Author == author & f.IsReply == false).ToList();
        }

        public ForumMessages GetForumMessage(string uniqueName)
        {
            return _context.ForumMessages.Where(f => f.UniqueName == uniqueName & f.IsReply == false).SingleOrDefault();
        }

        public List<ForumMessages> GetForumReplies(string uniqueName)
        {
            return _context.ForumMessages.Where(f => f.UniqueName == uniqueName & f.IsReply == true).ToList();
        }

        public bool AddForumMessage(string name, string content, string author, bool isReply, string forumID, string replyTo = null)
        {
            try
            {
                ForumMessages forumMessage = new ForumMessages();

                forumMessage.Author = author;
                forumMessage.Content = content;
                forumMessage.ForumID = forumID;
                forumMessage.IsReply = isReply;
                forumMessage.ReplyTo = replyTo;
                forumMessage.SubmissionDate = DateTime.Now;
                forumMessage.LastModified = DateTime.Now;
                forumMessage.Name = name;
                forumMessage.UniqueName = _unique.GetName(_stringsSanitizer.MakeUrlFriendly(name), "ForumMessages");

                _context.ForumMessages.Add(forumMessage);
                _context.SaveChanges();
            }
            catch
            {
                result = false;
            }

            return result;
        }

        public List<Images> GetImages()
        {
            return _context.Images.ToList();
        }

        public List<Images> GetImages(string uploader)
        {
            return _context.Images.Where(i => i.Uploader == uploader).ToList();
        }

        public List<ChatRooms> GetChatRooms()
        {
            return _context.ChatRooms.ToList();
        }

        public void AddChatRoom(string name, string topic = null)
        {
            ChatRooms r = new ChatRooms
            {
                Name = name,
                Topic = topic
            };
            _context.ChatRooms.Add(r);
            _context.SaveChanges();
        }

        public List<ChatMessages> GetChatMessages(int id)
        {
            return _context.ChatMessages.Where(c => c.ChatRoomID == id).ToList();
        }

        public void AddChatMessage(string author, string message, int chatRoomID)
        {
            ChatMessages m = new ChatMessages
            {
                ChatRoomID = chatRoomID,
                AuthorID = author,
                Message = message,
                SubmissionDate = DateTime.Now
            };
            _context.ChatMessages.Add(m);
            _context.SaveChanges();
        }
    }
}