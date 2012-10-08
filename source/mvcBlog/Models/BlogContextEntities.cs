using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace mvcBlog.Models
{
    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<SocialBlogStat> SocialBlogStats { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}