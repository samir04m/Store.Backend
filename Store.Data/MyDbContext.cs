using Store.Data.Entities;
using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace Store.Data
{
    public class MyDbContext : DbContext
    {
        static MyDbContext()
        {
            _ = SqlProviderServices.Instance;
        }

        public MyDbContext() : base("name=MyDbConnection") { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new Configurations.ProductConfigutation());
            modelBuilder.Configurations.Add(new Configurations.CategoryConfiguration());
            base.OnModelCreating(modelBuilder);
        }    
    }
}
