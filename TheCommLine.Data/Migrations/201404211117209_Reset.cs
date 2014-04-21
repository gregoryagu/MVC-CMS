namespace TheCommLine.Data.Context
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Reset : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.ContentEntities",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Key = c.String(),
            //            Data = c.String(),
            //            CreatedOn = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.PageRows",
            //    c => new
            //        {
            //            PageRowId = c.Int(nullable: false, identity: true),
            //            PageId = c.Int(nullable: false),
            //            Visible = c.Boolean(nullable: false),
            //            SortOrder = c.Int(nullable: false),
            //            PageLayout_PageLayoutId = c.Int(),
            //        })
            //    .PrimaryKey(t => t.PageRowId)
            //    .ForeignKey("dbo.PageLayouts", t => t.PageLayout_PageLayoutId)
            //    .Index(t => t.PageLayout_PageLayoutId);
            
            //CreateTable(
            //    "dbo.RowColumns",
            //    c => new
            //        {
            //            RowColumnId = c.Int(nullable: false, identity: true),
            //            PageRowId = c.Int(nullable: false),
            //            Visible = c.Boolean(nullable: false),
            //            Content = c.String(),
            //            ClassLg = c.String(),
            //            ClassMd = c.String(),
            //            ClassSm = c.String(),
            //            ClassXs = c.String(),
            //        })
            //    .PrimaryKey(t => t.RowColumnId)
            //    .ForeignKey("dbo.PageRows", t => t.PageRowId, cascadeDelete: true)
            //    .Index(t => t.PageRowId);
            
            //CreateTable(
            //    "dbo.PageLayouts",
            //    c => new
            //        {
            //            PageLayoutId = c.Int(nullable: false, identity: true),
            //            Key = c.String(),
            //            SortOrder = c.Int(nullable: false),
            //            IsVisible = c.Boolean(nullable: false),
            //        })
            //    .PrimaryKey(t => t.PageLayoutId);
            
            //CreateTable(
            //    "dbo.AspNetRoles",
            //    c => new
            //        {
            //            Id = c.String(nullable: false, maxLength: 128),
            //            Name = c.String(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Properties",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Key = c.String(),
            //            StringValue = c.String(),
            //            IntValue = c.Int(nullable: false),
            //            DateValue = c.DateTime(),
            //            BoolValue = c.Boolean(nullable: false),
            //            CreatedOn = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.AspNetUsers",
            //    c => new
            //        {
            //            Id = c.String(nullable: false, maxLength: 128),
            //            UserName = c.String(),
            //            PasswordHash = c.String(),
            //            SecurityStamp = c.String(),
            //            EmailAddress = c.String(),
            //            FirstName = c.String(),
            //            LastName = c.String(),
            //            MiddleName = c.String(),
            //            Discriminator = c.String(nullable: false, maxLength: 128),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.AspNetUserClaims",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            ClaimType = c.String(),
            //            ClaimValue = c.String(),
            //            User_Id = c.String(nullable: false, maxLength: 128),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
            //    .Index(t => t.User_Id);
            
            //CreateTable(
            //    "dbo.AspNetUserLogins",
            //    c => new
            //        {
            //            UserId = c.String(nullable: false, maxLength: 128),
            //            LoginProvider = c.String(nullable: false, maxLength: 128),
            //            ProviderKey = c.String(nullable: false, maxLength: 128),
            //        })
            //    .PrimaryKey(t => new { t.UserId, t.LoginProvider, t.ProviderKey })
            //    .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
            //    .Index(t => t.UserId);
            
            //CreateTable(
            //    "dbo.AspNetUserRoles",
            //    c => new
            //        {
            //            UserId = c.String(nullable: false, maxLength: 128),
            //            RoleId = c.String(nullable: false, maxLength: 128),
            //        })
            //    .PrimaryKey(t => new { t.UserId, t.RoleId })
            //    .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
            //    .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
            //    .Index(t => t.RoleId)
            //    .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserClaims", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.PageRows", "PageLayout_PageLayoutId", "dbo.PageLayouts");
            DropForeignKey("dbo.RowColumns", "PageRowId", "dbo.PageRows");
            DropIndex("dbo.AspNetUserClaims", new[] { "User_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.PageRows", new[] { "PageLayout_PageLayoutId" });
            DropIndex("dbo.RowColumns", new[] { "PageRowId" });
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Properties");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.PageLayouts");
            DropTable("dbo.RowColumns");
            DropTable("dbo.PageRows");
            DropTable("dbo.ContentEntities");
        }
    }
}
