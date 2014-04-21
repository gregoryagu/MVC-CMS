namespace TheCommLine.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Validation;
    using System.Diagnostics;

    using TheCommLine.Data.Migrations;

    //This is not used if Migrations are being used.
    public class DbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext> {
        
        protected override void Seed(ApplicationDbContext context) {


            try {
                Seeder.SeedAuthentication(context);
                Seeder.SeedLookupList(context);
                base.Seed(context);
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }
        }

        
    }
}
