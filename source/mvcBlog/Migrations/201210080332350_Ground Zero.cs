namespace mvcBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Web.Security;
    using System.Linq;
    using WebMatrix.WebData;
    
    public partial class GroundZero : DbMigration
    {
        public override void Up()
        {
            WebSecurity.InitializeDatabaseConnection(
                "DefaultConnection",
                "UserProfile",
                "UserId",
                "UserName", autoCreateTables: true);
            WebSecurity.CreateAccount("Admin", "admin1", false);

            if (!Roles.RoleExists("Administrator"))
                Roles.CreateRole("Administrator");
            if (!Roles.RoleExists("Blogger"))
                Roles.CreateRole("Blogger");
            if (!Roles.RoleExists("Reader"))
                Roles.CreateRole("Reader");
            if (!Roles.GetRolesForUser("Admin").Contains("Administrator"))
                Roles.AddUsersToRoles(new[] { "Admin" }, new[] { "Administrator" });
            //CreateTable(
            //    "dbo.UserProfile",
            //    c => new
            //        {
            //            UserId = c.Int(nullable: false, identity: true),
            //            UserName = c.String(nullable: false),
            //            FirstName = c.String(),
            //            LastName = c.String(),
            //            EMail = c.String(),
            //            Twitter = c.String(),
            //            Facebook = c.String(),
            //            WebSite = c.String(),
            //            isActive = c.Boolean(),
            //        })
            //    .PrimaryKey(t => t.UserId);
            
            //CreateTable(
            //    "dbo.Blogs",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            UserId = c.Int(nullable: false),
            //            Title = c.String(),
            //            Article = c.String(),
            //            Quote = c.String(),
            //            ShortDescription = c.String(),
            //            CreatedDate = c.DateTime(nullable: false),
            //            PublishedDate = c.DateTime(nullable: false),
            //            LastUpdated = c.DateTime(nullable: false),
            //            ArticleImage = c.String(),
            //            ImageDescription = c.String(),
            //            HeaderImage = c.String(),
            //            NoComments = c.Boolean(nullable: false),
            //            IsDraft = c.Boolean(nullable: false),
            //            IsPublished = c.Boolean(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Categories",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //            Image = c.String(),
            //            SecondaryImage = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Tags",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Comments",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            UserId = c.Int(nullable: false),
            //            CommentText = c.String(nullable: false),
            //            BlogId = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.Blogs", t => t.BlogId, cascadeDelete: true)
            //    .Index(t => t.BlogId);
            
            //CreateTable(
            //    "dbo.SocialBlogStats",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            SocialSite = c.String(nullable: false),
            //            SharedCount = c.Int(nullable: false),
            //            isActive = c.Boolean(nullable: false),
            //            BlogId = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.Blogs", t => t.BlogId, cascadeDelete: true)
            //    .Index(t => t.BlogId);
            
            //CreateTable(
            //    "dbo.CategoryBlogs",
            //    c => new
            //        {
            //            Category_Id = c.Int(nullable: false),
            //            Blog_Id = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => new { t.Category_Id, t.Blog_Id })
            //    .ForeignKey("dbo.Categories", t => t.Category_Id, cascadeDelete: true)
            //    .ForeignKey("dbo.Blogs", t => t.Blog_Id, cascadeDelete: true)
            //    .Index(t => t.Category_Id)
            //    .Index(t => t.Blog_Id);
            
            //CreateTable(
            //    "dbo.TagBlogs",
            //    c => new
            //        {
            //            Tag_Id = c.Int(nullable: false),
            //            Blog_Id = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => new { t.Tag_Id, t.Blog_Id })
            //    .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
            //    .ForeignKey("dbo.Blogs", t => t.Blog_Id, cascadeDelete: true)
            //    .Index(t => t.Tag_Id)
            //    .Index(t => t.Blog_Id);
            
        }
        
        public override void Down()
        {
            //DropIndex("dbo.TagBlogs", new[] { "Blog_Id" });
            //DropIndex("dbo.TagBlogs", new[] { "Tag_Id" });
            //DropIndex("dbo.CategoryBlogs", new[] { "Blog_Id" });
            //DropIndex("dbo.CategoryBlogs", new[] { "Category_Id" });
            //DropIndex("dbo.SocialBlogStats", new[] { "BlogId" });
            //DropIndex("dbo.Comments", new[] { "BlogId" });
            //DropForeignKey("dbo.TagBlogs", "Blog_Id", "dbo.Blogs");
            //DropForeignKey("dbo.TagBlogs", "Tag_Id", "dbo.Tags");
            //DropForeignKey("dbo.CategoryBlogs", "Blog_Id", "dbo.Blogs");
            //DropForeignKey("dbo.CategoryBlogs", "Category_Id", "dbo.Categories");
            //DropForeignKey("dbo.SocialBlogStats", "BlogId", "dbo.Blogs");
            //DropForeignKey("dbo.Comments", "BlogId", "dbo.Blogs");
            //DropTable("dbo.TagBlogs");
            //DropTable("dbo.CategoryBlogs");
            //DropTable("dbo.SocialBlogStats");
            //DropTable("dbo.Comments");
            //DropTable("dbo.Tags");
            //DropTable("dbo.Categories");
            //DropTable("dbo.Blogs");
            //DropTable("dbo.UserProfile");
            Roles.RemoveUserFromRole("Admin", "Administrator");
            Roles.DeleteRole("Administrator");
            Roles.DeleteRole("Blogger");
            Roles.DeleteRole("Reader");
        }
    }
}
