﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Week13Store.Models;

#nullable disable

namespace Week13Store.Data
{
    public partial class Group1ComputerStoreContext : DbContext
    {
        public Group1ComputerStoreContext()
        {
        }

        public Group1ComputerStoreContext(DbContextOptions<Group1ComputerStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrdersPayment> OrdersPayments { get; set; }
        public virtual DbSet<OrdersProduct> OrdersProducts { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.CustCity)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CustEmail)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CustFirstName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CustLastName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CustPhone)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CustState)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CustStreet)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CustZip)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.EmpCity)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.EmpDob)
                    .HasColumnType("date")
                    .HasColumnName("EmpDOB");

                entity.Property(e => e.EmpEmail)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.EmpFirstName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.EmpJobTitle)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.EmpLastName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.EmpState)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.EmpStreet)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.EmpSupervisor)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.EmpZip)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.OrderDate).HasColumnType("date");

                entity.Property(e => e.OrderStatus)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmpID");

                entity.HasOne(d => d.ReferenceNumNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ReferenceNum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RefNum");
            });

            modelBuilder.Entity<OrdersPayment>(entity =>
            {
                entity.HasKey(e => e.OrderPaymentId)
                    .HasName("PK_OrdPayID");

                entity.ToTable("Orders_Payment");

                entity.Property(e => e.OrderPaymentId).HasColumnName("OrderPaymentID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.OrdersPayments)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomID");

                entity.HasOne(d => d.ReferenceNumNavigation)
                    .WithMany(p => p.OrdersPayments)
                    .HasForeignKey(d => d.ReferenceNum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReferNum");
            });

            modelBuilder.Entity<OrdersProduct>(entity =>
            {
                entity.HasKey(e => e.OrderProductId)
                    .HasName("PK_OrdPrdID");

                entity.ToTable("Orders_Product");

                entity.Property(e => e.OrderProductId).HasColumnName("OrderProductID");

                entity.Property(e => e.OrdProPrice).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrdersProducts)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrdID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrdersProducts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProdID");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => e.ReferenceNum)
                    .HasName("PK_RefNum");

                entity.ToTable("Payment");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.PaidTotalPrice).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.PaymentDate).HasColumnType("date");

                entity.Property(e => e.PaymentTax).HasColumnType("decimal(5, 2)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CusID");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ProCost).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.ProDescription)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ProName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ProRevenue).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.ProType)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ProVendor)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}