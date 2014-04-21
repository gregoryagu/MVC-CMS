namespace TheCommLine.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using TheCommLine.Data.Entities;

    public sealed class Configuration : DbMigrationsConfiguration<TheCommLine.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "TheCommLine.Data.ApplicationDbContext";
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TheCommLine.Data.ApplicationDbContext context) {
            Seeder.SeedSiteOptions(context);
            Seeder.SeedAuthentication(context);
            Seeder.SeedPages(context);
        }

        
        
    }
}
