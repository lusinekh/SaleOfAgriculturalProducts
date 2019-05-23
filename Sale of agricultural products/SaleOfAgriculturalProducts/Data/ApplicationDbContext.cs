using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SaleOfAgriculturalProducts.Models;

namespace SaleOfAgriculturalProducts.Data
{
    public class ApplicationDbContext :  IdentityDbContext<ApplicationUser>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductItmsImage> ProductItmsImages { get; set; }

        public DbSet<ApplicationUserProduct> ApplicationUserProducts { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Product>(e =>
            {
                e.HasKey(b => b.ProductID);
                e.Property(b => b.ProductID).HasDefaultValueSql("(newid())");
                e.Property(b => b.Category).IsRequired();
                e.Property(b => b.MeasurementUnit).IsRequired();
                e.Property(b => b.PriceUnit).IsRequired();
                e.Property(b => b.Count).IsRequired();
                e.Property(b => b.Quality).IsRequired();
                e.Property(b => b.ProductionTime).IsRequired();   
                e.HasOne<ProductItmsImage>(b=>b.ProductItmsImage)
               .WithMany(b=>b.Products).HasForeignKey(b => b.ProductItmsImageId);

            }
            );

            modelBuilder.Entity<ProductItmsImage>(e =>
            {
                e.HasKey(b => b.ProductItmsImageId);
                e.Property(b => b.ProductItmsImageId).HasDefaultValueSql("(newid())");
                e.Property(b => b.Path).IsRequired();
                e.Property(b => b.ImageName).IsRequired();
                e.Property(b => b.Size).IsRequired();
                e.Property(b => b.Exstention).IsRequired();
            });

            modelBuilder.Entity<ApplicationUserProduct>().HasKey(sc => new { sc.ApplicationUserId, sc.ProductId });
        }

    }
}
