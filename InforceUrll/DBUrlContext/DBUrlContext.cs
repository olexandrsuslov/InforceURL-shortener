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

        public System.Data.Entity.DbSet<User> Users { get; set; }

        public System.Data.Entity.DbSet<Role> Roles { get; set; }
        public System.Data.Entity.DbSet<ShortUrl> Urls { get; set; }
    }
}