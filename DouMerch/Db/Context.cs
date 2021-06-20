using DouMerch.Models;
using DouMerch.Migrations;
using System.Data.Entity;

namespace DouMerch.Db
{
    public class Context : DbContext
    {
        public Context() : base("name=DouMerchDatabase")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Context, Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<UsersModel> Users { get; set; }
        public DbSet<OrderModel> Orders { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<CategoryModel> Category { get; set; }

    }
}