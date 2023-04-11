namespace TopMessenger.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TopMessenger.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TopMessenger.Data.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TopMessenger.Data.AppDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            //context.Users.Add(new User()
            //{
            //    FirstName = "First Name"
            //});
            //context.Users.Add(new User()
            //{
            //    FirstName = "Second Name"
            //});
            //context.Users.Add(new User()
            //{
            //    FirstName = "Third Name"
            //});
        }
    }
}
