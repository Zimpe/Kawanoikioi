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
        public DbSet<Articles> Articles { get; set; }
        public DbSet<ChatMessages> ChatMessages { get; set; }
        public DbSet<ChatRooms> ChatRooms { get; set; }
        public DbSet<Errors> Errors { get; set; }
        public DbSet<Forums> Forums { get; set; }
        public DbSet<ForumCategories> ForumCategories { get; set; }
        public DbSet<ForumMessages> ForumMessages { get; set; }
        public DbSet<Images> Images { get; set; }
    }
}