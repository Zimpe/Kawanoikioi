using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.IO;

namespace Kawanoikioi.Models
{
    public class KawanoikioiDbInit : DropCreateDatabaseIfModelChanges<KawanoikioiDbContext>
    {
        protected override void Seed(KawanoikioiDbContext context)
        {
            Articles art = new Articles
            {
                ID = 1,
                Author = "System",
                Name = "Welcome to Kawanoikioi",
                UniqueName = "Welcome",
                Content = "Hello and welcome to your new installment of Kawanoikioi. <br />It is recommended that you either edit this article so that it suits your website or remove it completly. <br />In order to change/remove this article please go to the Administration section of the system. Please note you must be part of the Administrators role otherwise you will not be given access.",
                IsPublished = true,
                SubmissionDate = DateTime.Now,
                LastModified = DateTime.Now
            };
            context.Articles.Add(art);

            ForumCategories category = new ForumCategories
            {
                ID = 1,
                Name = "First Category (Please rename this category)",
                OrderID = 1
            };
            context.ForumCategories.Add(category);

            ForumMessages forumMsg = new ForumMessages
            {
                ID = 1,
                Name = "Welcome to your Kawanoikioi Forum.",
                UniqueName = "Welcome",
                Author = "System",
                Content = "This is just a first message to have something to show in the forum to show that the database is correctly setup. Please remove or alter this message to your taste and needs.",
                IsReply = false,
                ForumID = "First-Forum",
                ReplyTo = null,
                SubmissionDate = DateTime.Now,
                LastModified = DateTime.Now
            };
            context.ForumMessages.Add(forumMsg);

            Forums forum = new Forums
            {
                ID = 1,
                CategoryID = 1,
                Name = "First Forum",
                UniqueName = "First-Forum",
                Description = "Please either change this forum and category to suit your needs, or remove it, and setup the architecture you want the forums to have",
                OrderID = 1
            };
            context.Forums.Add(forum);

            base.Seed(context);
        }
    }
}