﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repositories;

public partial class Prudoct_Kategory_webApi : DbContext
{
    public Prudoct_Kategory_webApi(DbContextOptions<Prudoct_Kategory_webApi> options)
        : base(options)
    {
    }
    public Prudoct_Kategory_webApi() { }
    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.Name).IsFixedLength();
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasOne(d => d.User).WithMany(p => p.Orders).HasConstraintName("FK_UserOrder");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ORDER_IREM");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems).HasConstraintName("FK_OrederId_Item");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems).HasConstraintName("FK_PRODUCT_Id_Item");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Prudocts");

            entity.Property(e => e.Description).IsFixedLength();
            entity.Property(e => e.Image).IsFixedLength();
            entity.Property(e => e.Name).IsFixedLength();

            entity.HasOne(d => d.Category).WithMany(p => p.Products).HasConstraintName("FK_PRODUCT_Category");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}