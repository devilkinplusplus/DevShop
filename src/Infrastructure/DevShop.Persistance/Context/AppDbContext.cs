using DevShop.Domain.Entities.Concrete;
using DevShop.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Persistance.Context
{
    public class AppDbContext : IdentityDbContext<AppUser, IdentityRole, string>
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Product> Product { get; set; }
        public DbSet<Catagory> Catagory { get; set; }
        public DbSet<SubCatagory> SubCatagory { get; set; }
        public DbSet<CatagorySub> CatagorySub { get; set; }
        public DbSet<Picture> Picture { get; set; }
        public DbSet<ProductPicture> ProductPicture { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<AppUser>().ToTable("Users");
            builder.Entity<IdentityRole>().ToTable("Roles");

            //Many to many relationship between product and pictures
            builder.Entity<ProductPicture>().HasKey(k => new {k.Id});

            builder.Entity<ProductPicture>()
                .HasOne(k => k.Product)
                .WithMany(k => k.ProductPictures)
                .HasForeignKey(k => k.ProductId);

            builder.Entity<ProductPicture>()
                .HasOne(k => k.Picture)
                .WithMany(k => k.ProductPictures)
                .HasForeignKey(k => k.PictureId);

            //many to many between catagory and subcatagory
            builder.Entity<CatagorySub>().HasKey(k => new { k.Id });

            builder.Entity<CatagorySub>()
                .HasOne(k => k.Catagory)
                .WithMany(k => k.CatagorySubs)
                .HasForeignKey(k => k.CatagoryId);

            builder.Entity<CatagorySub>()
             .HasOne(k => k.SubCatagory)
             .WithMany(k => k.CatagorySubs)
             .HasForeignKey(k => k.SubCatagoryId);

            //One to many between product and catagory
            builder.Entity<SubCatagory>()
                .HasMany(k => k.Products)
                .WithOne(k => k.SubCatagory)
                .HasForeignKey(k => k.SubCatagoryId);
        }
    }
}
