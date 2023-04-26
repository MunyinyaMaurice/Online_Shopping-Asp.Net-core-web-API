//using Microsoft.EntityFrameworkCore;
//using Shop_online.Model;
//using System.Diagnostics.Metrics;

//namespace Shop_online.Data
//{
//    public class DataContext : DbContext
//    {
//        public DataContext(DbContextOptions<DataContext> options) : base(options)
//        {

//        }

//        public DbSet<Product> Product { get; set; }
//        public DbSet<Customer> Customer { get; set; }
//        public DbSet<Order> Order { get; set; }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<Order>()
//                    .HasKey(ord => new { ord.p_id, ord.customer_id });

//            modelBuilder.Entity<Order>()
//                    .HasOne(p => p.Product)
//                    .WithMany(pc => pc.order)
//                    .HasForeignKey(p => p.p_id);
//            modelBuilder.Entity<Order>()
//                    .HasOne(p => p.Customer)
//                    .WithMany(pc => pc.order)
//                    .HasForeignKey(c => c.customer_id);


//        }
//    }
//}
using Microsoft.EntityFrameworkCore;
using Shop_online.Model;
using System.Diagnostics.Metrics;

namespace Shop_online.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Order> Order { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                    .HasKey(ord => new { ord.order_id });

            modelBuilder.Entity<Order>()
                    .HasOne(p => p.Customer)
                    .WithMany(c => c.Orders)
                    .HasForeignKey(p => p.customer_id);

            modelBuilder.Entity<Order>()
                    .HasMany(p => p.Products)
                    .WithMany(p => p.Orders);
        }

    }
}


