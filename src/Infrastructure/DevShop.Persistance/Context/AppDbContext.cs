﻿using DevShop.Domain.Entities.Concrete;
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
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Wishlist> Wishlist { get; set; }
        public DbSet<Sale> Sales { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<AppUser>().ToTable("Users");
            builder.Entity<IdentityRole>().ToTable("Roles");

            //Many to many relationship between product and pictures
            builder.Entity<ProductPicture>().HasKey(k => new { k.Id });

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

            //One to many between subcatagory and product
            builder.Entity<SubCatagory>()
                .HasMany(k => k.Products)
                .WithOne(k => k.SubCatagory)
                .HasForeignKey(k => k.SubCatagoryId);
            //One to many between product and reviews
            builder.Entity<Product>()
                .HasMany(x => x.Reviews)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductId);
            //One to many between product and cart
            builder.Entity<Product>()
                .HasMany(x => x.Carts)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductId);
            //one to many between product and wishlist
            builder.Entity<Product>()
                .HasMany(x => x.Wishlists)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductId);
            //one to many between product and sales
            builder.Entity<Product>()
                    .HasMany(x => x.Sales)
                    .WithOne(x => x.Product)
                    .HasForeignKey(x => x.ProductId);
            //2 foreign keys from AppUser table to Sales table
            builder.Entity<Sale>()
                    .HasOne(x => x.Seller)
                    .WithMany()
                    .HasForeignKey(x => x.SellerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            builder.Entity<Sale>()
                   .HasOne(x => x.Buyer)
                   .WithMany()
                   .HasForeignKey(x => x.BuyerId)
                   .OnDelete(DeleteBehavior.ClientSetNull); 
            //one to many between Contact and Reply
            builder.Entity<Contact>()
                    .HasMany(x=>x.Replies)
                    .WithOne(x=>x.Contact)
                    .HasForeignKey(x=>x.ContactId);
        }
    }
}
