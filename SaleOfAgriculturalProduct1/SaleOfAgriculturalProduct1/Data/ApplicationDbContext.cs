using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SaleOfAgriculturalProduct1.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductItmsImage> ProductItmsImages { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<MeasurementUnit> MeasurementUnits { get; set; }
        public DbSet<Quality> Qualitys { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>(e =>            {
                e.HasKey(b => b.ProductID);
                e.Property(b => b.ProductID).HasDefaultValueSql("(newid())");  
                e.Property(b => b.PriceUnit).IsRequired();
                e.Property(b => b.ShowAllow).IsRequired();
                e.Property(b => b.Count).IsRequired();               
                e.Property(b => b.ProductionTime).IsRequired();
                e.HasOne<ProductItmsImage>(b => b.ProductItmsImage)
                .WithMany(b => b.Products).HasForeignKey(b => b.ProductItmsImageId);
                e.HasOne<Category>(b => b.Category)
                .WithMany(b => b.Products).HasForeignKey(b => b.CategoryId);
                e.HasOne<MeasurementUnit>(b => b.MeasureUnit)
                .WithMany(b => b.Products).HasForeignKey(b => b.MeasurementUnitId);
                e.HasOne<Quality>(b => b.Qualitys)
              .WithMany(b => b.Products).HasForeignKey(b => b.QualityId);
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

            modelBuilder.Entity<Category>(e =>
            {
                e.HasKey(b => b.CategoryId);
                e.Property(b => b.CategoryId).HasDefaultValueSql("(newid())");
                e.Property(b => b.CategoryName).IsRequired();               
            });

            modelBuilder.Entity<MeasurementUnit>(e =>
            {
                e.HasKey(b => b.MeasurementUnitId);
                e.Property(b => b.MeasurementUnitId).HasDefaultValueSql("(newid())");
                e.Property(b => b.Unit).IsRequired();
            });

            modelBuilder.Entity<Quality>(e =>
            {
                e.HasKey(b => b.QualityId);
                e.Property(b => b.QualityId).HasDefaultValueSql("(newid())");
                e.Property(b => b.QualityName).IsRequired();
            });          

        }
    }
}
