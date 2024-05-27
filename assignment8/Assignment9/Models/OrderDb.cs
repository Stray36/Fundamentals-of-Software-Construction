using Microsoft.EntityFrameworkCore;

namespace assignment9.Models
{
    public class OrderDb : DbContext
    {
        public OrderDb(DbContextOptions<OrderDb> options)
            : base(options)
        {
             this.Database.EnsureCreated(); //自动建库建表
        }
        public DbSet<Order> Orders { get; set; }

        public DbSet<Goods> Goods { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}