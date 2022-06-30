﻿// <auto-generated />
using System;
using LemonadeStand.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LemonadeStand.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20220629214601_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LemonadeStand.Abstractions.Entities.LemonadeType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("Created")
                        .HasDefaultValueSql("getdate()");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("datetime")
                        .HasColumnName("Deleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Name");

                    b.Property<DateTime>("Udpdated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime")
                        .HasColumnName("Updated")
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("Id");

                    b.ToTable("LemonadeType", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2022, 6, 29, 17, 46, 0, 880, DateTimeKind.Local).AddTicks(9420),
                            Name = "Regular Lemonade",
                            Udpdated = new DateTime(2022, 6, 29, 17, 46, 0, 880, DateTimeKind.Local).AddTicks(9420)
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2022, 6, 29, 17, 46, 0, 880, DateTimeKind.Local).AddTicks(9430),
                            Name = "Pink Lemonade",
                            Udpdated = new DateTime(2022, 6, 29, 17, 46, 0, 880, DateTimeKind.Local).AddTicks(9430)
                        });
                });

            modelBuilder.Entity("LemonadeStand.Abstractions.Entities.LineItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("Cost")
                        .HasColumnType("float")
                        .HasColumnName("Cost");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("Created")
                        .HasDefaultValueSql("getdate()");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("datetime")
                        .HasColumnName("Deleted");

                    b.Property<int>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("OrderId");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("ProductId");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("Quantity");

                    b.Property<DateTime>("Udpdated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime")
                        .HasColumnName("Updated")
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("LineIitem", (string)null);
                });

            modelBuilder.Entity("LemonadeStand.Abstractions.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("Created")
                        .HasDefaultValueSql("getdate()");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("datetime")
                        .HasColumnName("Deleted");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(75)")
                        .HasColumnName("Email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("FirstName");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(75)")
                        .HasColumnName("LastName");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("varchar(75)")
                        .HasColumnName("Phone");

                    b.Property<double>("TotalCost")
                        .HasColumnType("float");

                    b.Property<DateTime>("Udpdated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime")
                        .HasColumnName("Updated")
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("Id");

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("LemonadeStand.Abstractions.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("Amount")
                        .HasColumnType("float")
                        .HasColumnName("Amount");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("Created")
                        .HasDefaultValueSql("getdate()");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("datetime")
                        .HasColumnName("Deleted");

                    b.Property<int>("LemonadeTypeId")
                        .HasColumnType("int")
                        .HasColumnName("LemonadeTypeId");

                    b.Property<int>("SizeId")
                        .HasColumnType("int")
                        .HasColumnName("SizeId");

                    b.Property<DateTime>("Udpdated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime")
                        .HasColumnName("Updated")
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("Id");

                    b.HasIndex("LemonadeTypeId");

                    b.HasIndex("SizeId");

                    b.ToTable("Product", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 0.75,
                            Created = new DateTime(2022, 6, 29, 17, 46, 0, 881, DateTimeKind.Local).AddTicks(5200),
                            LemonadeTypeId = 1,
                            SizeId = 1,
                            Udpdated = new DateTime(2022, 6, 29, 17, 46, 0, 881, DateTimeKind.Local).AddTicks(5200)
                        },
                        new
                        {
                            Id = 2,
                            Amount = 1.5,
                            Created = new DateTime(2022, 6, 29, 17, 46, 0, 881, DateTimeKind.Local).AddTicks(5210),
                            LemonadeTypeId = 1,
                            SizeId = 2,
                            Udpdated = new DateTime(2022, 6, 29, 17, 46, 0, 881, DateTimeKind.Local).AddTicks(5210)
                        },
                        new
                        {
                            Id = 3,
                            Amount = 0.75,
                            Created = new DateTime(2022, 6, 29, 17, 46, 0, 881, DateTimeKind.Local).AddTicks(5220),
                            LemonadeTypeId = 2,
                            SizeId = 1,
                            Udpdated = new DateTime(2022, 6, 29, 17, 46, 0, 881, DateTimeKind.Local).AddTicks(5220)
                        },
                        new
                        {
                            Id = 4,
                            Amount = 1.5,
                            Created = new DateTime(2022, 6, 29, 17, 46, 0, 881, DateTimeKind.Local).AddTicks(5230),
                            LemonadeTypeId = 2,
                            SizeId = 2,
                            Udpdated = new DateTime(2022, 6, 29, 17, 46, 0, 881, DateTimeKind.Local).AddTicks(5230)
                        });
                });

            modelBuilder.Entity("LemonadeStand.Abstractions.Entities.Size", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("Created")
                        .HasDefaultValueSql("getdate()");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("datetime")
                        .HasColumnName("Deleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Name");

                    b.Property<DateTime>("Udpdated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime")
                        .HasColumnName("Updated")
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("Id");

                    b.ToTable("Size", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2022, 6, 29, 17, 46, 0, 881, DateTimeKind.Local).AddTicks(820),
                            Name = "Regular Size",
                            Udpdated = new DateTime(2022, 6, 29, 17, 46, 0, 881, DateTimeKind.Local).AddTicks(830)
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2022, 6, 29, 17, 46, 0, 881, DateTimeKind.Local).AddTicks(840),
                            Name = "LargeSize",
                            Udpdated = new DateTime(2022, 6, 29, 17, 46, 0, 881, DateTimeKind.Local).AddTicks(840)
                        });
                });

            modelBuilder.Entity("LemonadeStand.Abstractions.Entities.LineItem", b =>
                {
                    b.HasOne("LemonadeStand.Abstractions.Entities.Order", "Order")
                        .WithMany("LineItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("ForeignKey_Order_LineItems");

                    b.HasOne("LemonadeStand.Abstractions.Entities.Product", "Product")
                        .WithMany("LineItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("ForeignKey_Product_LineItems");

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("LemonadeStand.Abstractions.Entities.Product", b =>
                {
                    b.HasOne("LemonadeStand.Abstractions.Entities.LemonadeType", "LemonadeTypes")
                        .WithMany("Products")
                        .HasForeignKey("LemonadeTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("ForeignKey_Product_LemonadeTypes");

                    b.HasOne("LemonadeStand.Abstractions.Entities.Size", "Sizes")
                        .WithMany("Products")
                        .HasForeignKey("SizeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("ForeignKey_Product_Sizes");

                    b.Navigation("LemonadeTypes");

                    b.Navigation("Sizes");
                });

            modelBuilder.Entity("LemonadeStand.Abstractions.Entities.LemonadeType", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("LemonadeStand.Abstractions.Entities.Order", b =>
                {
                    b.Navigation("LineItems");
                });

            modelBuilder.Entity("LemonadeStand.Abstractions.Entities.Product", b =>
                {
                    b.Navigation("LineItems");
                });

            modelBuilder.Entity("LemonadeStand.Abstractions.Entities.Size", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
