
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using InforceUrll.Models;

namespace InforceUrll.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<InforceUrll.DBUrlContext.DBUrlContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
        
        protected override void Seed(DBUrlContext.DBUrlContext context)
        {
            if (context.Roles.Any())
            {
                return;   // DB has been seeded
            }
           
            context.Roles.AddOrUpdate(x => x.Id,
                new Role() { Id = 1, Name = "admin" },
                new Role() { Id = 2, Name = "user" }
            );
            context.SaveChanges();

            context.Users.AddOrUpdate(x => x.Id,
                new User() { Email = "admin1@gmail.com", Password = "123", RoleId = 1 },
                new User() { Email = "user1@gmail.com", Password = "456", RoleId = 2}
            );
            context.SaveChanges();
        }
    } 
}