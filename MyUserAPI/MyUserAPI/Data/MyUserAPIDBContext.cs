using Microsoft.EntityFrameworkCore;
using MyUserAPI.models;

namespace MyUserAPI.Data
{
    public class MyUserAPIDBContext : DbContext
    {
        public MyUserAPIDBContext(DbContextOptions options) : base(options)
        {
            this.Database.EnsureCreated(); 
        }

/*        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=webDB;Trusted_Connection=True;");
            // optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["BloggingDatabase"].ConnectionString);
        }
  */
        
        public DbSet<MyUser> Users { get; set; }
    }
}
