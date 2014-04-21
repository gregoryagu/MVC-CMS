namespace TheCommLine.Data.Context
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmigrationdroptables : DbMigration
    {
        public override void Up()
        {
            
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PageLayouts",
                c => new
                    {
                        PageLayoutId = c.Int(nullable: false, identity: true),
                        Key = c.String(),
                        SortOrder = c.Int(nullable: false),
                        IsVisible = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PageLayoutId);
            
            CreateTable(
                "dbo.RowColumns",
                c => new
                    {
                        RowColumnId = c.Int(nullable: false, identity: true),
                        PageRowId = c.Int(nullable: false),
                        Visible = c.Boolean(nullable: false),
                        Content = c.String(),
                        ClassLg = c.String(),
                        ClassMd = c.String(),
                        ClassSm = c.String(),
                        ClassXs = c.String(),
                    })
                .PrimaryKey(t => t.RowColumnId);
            
            CreateTable(
                "dbo.PageRows",
                c => new
                    {
                        PageRowId = c.Int(nullable: false, identity: true),
                        PageId = c.Int(nullable: false),
                        Visible = c.Boolean(nullable: false),
                        SortOrder = c.Int(nullable: false),
                        PageLayout_PageLayoutId = c.Int(),
                    })
                .PrimaryKey(t => t.PageRowId);
            
            CreateIndex("dbo.PageRows", "PageLayout_PageLayoutId");
            CreateIndex("dbo.RowColumns", "PageRowId");
            AddForeignKey("dbo.PageRows", "PageLayout_PageLayoutId", "dbo.PageLayouts", "PageLayoutId");
            AddForeignKey("dbo.RowColumns", "PageRowId", "dbo.PageRows", "PageRowId", cascadeDelete: true);
        }
    }
}
