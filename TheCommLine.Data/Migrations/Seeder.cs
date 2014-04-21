using System.Linq;

namespace TheCommLine.Data.Migrations
{
    using System;
    using System.Diagnostics;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using TheCommLine.Data.Entities;

    public static class Seeder
    {

         //<option value="SeekingWork">Seeking Work</option>
         //                       <option value="EmploymentOpportunities">Employment Opportunities</option>
         //                       <option value="BusinessOpportunities">Business Opportunities</option>
         //                       <option value="ForSale">For Sale</option>
         //                       <option value="Wanted">Wanted</option>
         //                       <option value="RealEstateForSale">Real Estate For Sale</option>
         //                       <option value="Rentals">Rentals: Home/Office/Apt</option>
         //                       <option value="Personals">Personals</option>


        public static void SeedLookupList(ApplicationDbContext context) {
            var list = new ListEntity() { ListKey = "ClassifiedCategories", Name = "Classified Ad Categories"};
            context.ListEntities.Add(list);
            list.Items.Add(new ListItemEntity(){Text = "Rentals: Home/Office/Apt", Value = "Rentals"});
            list.Items.Add(new ListItemEntity() { Text = "Seeking Work", Value = "Seeking-Work" });
            list.Items.Add(new ListItemEntity() { Text = "Employment Opportunities", Value = "Employment-Opportunities" });
            list.Items.Add(new ListItemEntity() { Text = "For Sale", Value = "For-Sale" });
            list.Items.Add(new ListItemEntity() { Text = "Wanted", Value = "Wanted" });
            list.Items.Add(new ListItemEntity() { Text = "Real Estate For Sale", Value = "Real-Estate" });
            list.Items.Add(new ListItemEntity() { Text = "Personals", Value = "Personals" });
            context.SaveChanges();
        }

       
        public static void SeedAuthentication(ApplicationDbContext context) {
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };
                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "Admin"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "Admin" };

                manager.Create(user, "password");
                manager.AddToRole(user.Id, "Admin");
            }

        }


        
    }
}
