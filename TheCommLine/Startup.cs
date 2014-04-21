using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TheCommLine.Startup))]
namespace TheCommLine
{
    using System.Data.Entity;

    using TheCommLine.Data;
    using TheCommLine.Data.Context;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //Database.SetInitializer(new DbInitializer());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
            var context = new ApplicationDbContext();
            context.Database.Initialize(true);
            
        }
    }
}
