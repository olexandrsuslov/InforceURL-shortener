
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
            // if (context.Roles.Any())
            // {
            //     return;   // DB has been seeded
            // }
            //
            // context.Roles.AddOrUpdate(x => x.Id,
            //     new Role() { Id = 1, Name = "admin" },
            //     new Role() { Id = 2, Name = "user" }
            // );
            // context.SaveChanges();
            //
            // context.Users.AddOrUpdate(x => x.Id,
            //     new User() { Email = "admin1@gmail.com", Password = "123", RoleId = 1 },
            //     new User() { Email = "user1@gmail.com", Password = "456", RoleId = 2}
            // );
            // context.SaveChanges();
            
            context.AboutStrs.AddOrUpdate(x => x.Id,
                new AboutContent(){AlgoStr = "So, how works an URL shortener?" +
                                             "\nBasicaly, we store the URL in database, so it has a numeric ID, an we convert it to a another base in order to have a stringified version of the ID." +
                                             "\nWhen we have the short URL the process is:" +
                                             "\n  -convert the stringified ID to the numeric ID." +
                                             "\n  -load the data from DB." +
                                             "\n  -redirect to the original URL using an HTTP redirection."});
            context.SaveChanges();
        }
    } 
}