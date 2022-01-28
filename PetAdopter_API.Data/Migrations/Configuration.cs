namespace PetAdopter_API.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PetAdopter_API.Data.ApplicationDbContext>
    {
        public Configuration()
        {
<<<<<<< HEAD
            AutomaticMigrationsEnabled = false;
=======
            AutomaticMigrationsEnabled = true;
>>>>>>> 02292f0c14c4d9d4a55d5636a46e98b7dee13559
        }

        protected override void Seed(PetAdopter_API.Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
