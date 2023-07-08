using System.Data.Entity;
using InforceUrll.Models;


namespace InforceUrll.DBUrlContext
{
    public class DBUrlContext : DbContext
    {
        public DBUrlContext() : base("Data Source=localhost;Initial Catalog=master;User=SA;Password=reallyStrongPwd123;TrustServerCertificate=true;")
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }
        public DbSet<ShortUrl> Urls { get; set; }
        public DbSet<AboutContent> AboutStrs { get; set; }
    }
}