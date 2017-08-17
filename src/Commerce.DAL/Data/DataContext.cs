using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commerce.Model.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Commerce.DAL.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        /// <summary>
        /// You can either pass the Name of a connection string from web config or explicity declare one
        /// </summary>
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // ef identity tables renamed
            builder.Entity<User>().ToTable("Users");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            builder.Entity<IdentityRole>().ToTable("Roles");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");

            //new BasketMap().Map(builder);
        }

        /// <summary>
        /// All persistent entities must be declared
        /// </summary>
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        //public virtual DbSet<Customer> Customers { get; set; }
        public virtual new DbSet<User> Users { get; set; }
        public virtual DbSet<Basket> Baskets { get; set; }
        public virtual DbSet<BasketItem> BasketItems { get; set; }
        public virtual DbSet<Voucher> Vouchers { get; set; }
        public virtual DbSet<BasketVoucher> BasketVouchers { get; set; }
        public virtual DbSet<VoucherType> VoucherTypes { get; set; }
    }
}
