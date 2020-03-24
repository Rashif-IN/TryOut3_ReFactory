
using Microsoft.EntityFrameworkCore;
using payment_handler.Models;

namespace payment_handler
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> opt) : base(opt) { }

        public DbSet<user_model> user { get; set; }

        public DbSet<paymentModel> payments { get; set; }

        public DbSet<productModel> products { get; set; }

        public DbSet<orderModel> orders { get; set; }

        public DbSet<order_detailsModel> Order_Details { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder
        //        .Entity<paymentModel>()
        //        .HasOne(X => X.OrderModel)
        //        .WithMany()
        //        .HasForeignKey(X => X.order_id);

        //    modelBuilder
        //        .Entity<orderModel>()
        //        .HasOne(X => X.user_Model)
        //        .WithMany()
        //        .HasForeignKey(X => X.user_id);


        //}
    }
}
