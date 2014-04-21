using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCommLine.Data.Context
{
    using System.Data.Entity.Migrations;

    using TheCommLine.Data.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext> {
        public Configuration() {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context) {
            //Seeder.SeedLookupList(context);
            base.Seed(context);
        }
    }
}
