using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data;
using System.Data.Objects;
using System.Data.Entity.Infrastructure;

namespace Kawanoikioi.Models
{
    public partial class KawanoikioiDbContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }
        public DbSet<ChatRoom> ChatRooms { get; set; }
        public DbSet<Errors> Errors { get; set; }
        public DbSet<Forum> Forums { get; set; }
        public DbSet<ForumCategory> ForumCategories { get; set; }
        public DbSet<ForumMessage> ForumMessages { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Video> Videos { get; set; }
    }
}