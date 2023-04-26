//using Microsoft.EntityFrameworkCore;
//using Shop_online.Data;
//using Shop_online.Model;

//namespace Shop_online
//{
//    public class Seed
//    {
//        private readonly DataContext dataContext;
//        public Seed(DataContext context)
//        {
//            this.dataContext = context;
//        }
//        public void SeedDataContext()
//        {
//            protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            // Configure relationships
//            modelBuilder.Entity<Order>()
//                    .HasKey(ord => new { ord.order_id });

//            modelBuilder.Entity<Order>()
//                    .HasOne(p => p.Customer)
//                    .WithMany(c => c.Orders)
//                    .HasForeignKey(p => p.customer_id);

//            modelBuilder.Entity<Order>()
//                    .HasMany(p => p.Products)
//                    .WithMany(p => p.Orders);

//            // Seed data
//            modelBuilder.Entity<Product>().HasData(
//                new Product { p_id = 1, product_name = "Product 1", product_price = 10.0f },
//                new Product { p_id = 2, product_name = "Product 2", product_price = 20.0f },
//                new Product { p_id = 3, product_name = "Product 3", product_price = 30.0f }
//            );

//            modelBuilder.Entity<Customer>().HasData(
//                new Customer { customer_id = 1, customer_names = "Customer 1", customer_email = "customer1@example.com" },
//                new Customer { customer_id = 2, customer_names = "Customer 2", customer_email = "customer2@example.com" },
//                new Customer { customer_id = 3, customer_names = "Customer 3", customer_email = "customer3@example.com" }
//            );
//        }

//    }
//}


using Microsoft.EntityFrameworkCore;
using Shop_online.Data;
using Shop_online.Model;

namespace Shop_online
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }
        public void SeedDataContext()
        {
            // Seed data
            dataContext.Product.AddRange(
                new Product { p_id = 1, product_name = "Product 1", product_price = 10.0f },
                new Product { p_id = 2, product_name = "Product 2", product_price = 20.0f },
                new Product { p_id = 3, product_name = "Product 3", product_price = 30.0f }
            );

            dataContext.Customer.AddRange(
                new Customer { customer_id = 1, customer_names = "Customer 1", customer_email = "customer1@example.com" },
                new Customer { customer_id = 2, customer_names = "Customer 2", customer_email = "customer2@example.com" },
                new Customer { customer_id = 3, customer_names = "Customer 3", customer_email = "customer3@example.com" }
            );

            dataContext.Order.AddRange(
                new Order { order_id = 1, customer_id = 1 },
                new Order { order_id = 2, customer_id = 2 },
                new Order { order_id = 3, customer_id = 3 }
            );

            dataContext.SaveChanges();

            // Configure relationships
            dataContext.Order
                .Include(o => o.Customer)
                .Include(o => o.Products)
                .ThenInclude(p => p.p_id)
                .ToList();
        }
    }
}
