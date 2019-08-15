using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using product_manager;
namespace product_manager.Models
{
    public partial class pm_mvcContext : DbContext
    {
        public pm_mvcContext()
        {
        }

        public pm_mvcContext(DbContextOptions<pm_mvcContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductCategory> ProductCategory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                AppConfig appConfig = AppConfig.GetAppConfig();
                optionsBuilder.UseNpgsql(appConfig.DbConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ProductCategoryId).HasColumnName("product_category_id");

                entity.Property(e => e.ProductDescription)
                    .IsRequired()
                    .HasColumnName("product_description")
                    .HasMaxLength(1000);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasColumnName("product_name")
                    .HasMaxLength(200);

                entity.Property(e => e.ProductPrice)
                    .HasColumnName("product_price")
                    .HasColumnType("numeric(10,2)");

                entity.HasOne(d => d.ProductCategory)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.ProductCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("product_product_category_id_fkey");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.ToTable("product_category");

                entity.HasIndex(e => e.CategoryName)
                    .HasName("product_category_category_name_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasColumnName("category_name")
                    .HasMaxLength(200);
            });
        }
    }
}
