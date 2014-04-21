namespace TheCommLine.Data.Context
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveRowColumn : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.RowColumns");
        }
        
        public override void Down()
        {
        }
    }
}
