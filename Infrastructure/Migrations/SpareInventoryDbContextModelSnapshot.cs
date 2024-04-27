﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(SpareInventoryDbContext))]
    partial class SpareInventoryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Core.Domain.Entities.Brand", b =>
                {
                    b.Property<Guid>("BrandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("BrandId");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("Core.Domain.Entities.Price", b =>
                {
                    b.Property<Guid>("PriceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)");

                    b.Property<decimal>("SellPrice")
                        .HasColumnType("smallmoney");

                    b.Property<Guid>("SpareBrandId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("smallmoney");

                    b.HasKey("PriceId");

                    b.HasIndex("SpareBrandId")
                        .IsUnique();

                    b.ToTable("Prices");
                });

            modelBuilder.Entity("Core.Domain.Entities.Spare", b =>
                {
                    b.Property<Guid>("SpareId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comments")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Group")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Keyword")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("OemCode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Sku")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("VehicleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("SpareId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Spares");
                });

            modelBuilder.Entity("Core.Domain.Entities.SpareBrand", b =>
                {
                    b.Property<Guid>("SpareBrandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BrandId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CodeByBrand")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<short>("Quantity")
                        .HasColumnType("smallint");

                    b.Property<Guid>("SpareId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.HasKey("SpareBrandId");

                    b.HasIndex("BrandId");

                    b.HasIndex("SpareId");

                    b.ToTable("SpareBrands");
                });

            modelBuilder.Entity("Core.Domain.Entities.Vehicle", b =>
                {
                    b.Property<Guid>("VehicleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Model")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<short?>("Year")
                        .HasColumnType("smallint");

                    b.HasKey("VehicleId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("Core.Domain.Entities.Price", b =>
                {
                    b.HasOne("Core.Domain.Entities.SpareBrand", "SpareBrand")
                        .WithOne("Price")
                        .HasForeignKey("Core.Domain.Entities.Price", "SpareBrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SpareBrand");
                });

            modelBuilder.Entity("Core.Domain.Entities.Spare", b =>
                {
                    b.HasOne("Core.Domain.Entities.Vehicle", "Vehicle")
                        .WithMany("Spares")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("Core.Domain.Entities.SpareBrand", b =>
                {
                    b.HasOne("Core.Domain.Entities.Brand", "Brand")
                        .WithMany("SpareBrands")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Domain.Entities.Spare", "Spare")
                        .WithMany("SpareBrands")
                        .HasForeignKey("SpareId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Spare");
                });

            modelBuilder.Entity("Core.Domain.Entities.Brand", b =>
                {
                    b.Navigation("SpareBrands");
                });

            modelBuilder.Entity("Core.Domain.Entities.Spare", b =>
                {
                    b.Navigation("SpareBrands");
                });

            modelBuilder.Entity("Core.Domain.Entities.SpareBrand", b =>
                {
                    b.Navigation("Price")
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Domain.Entities.Vehicle", b =>
                {
                    b.Navigation("Spares");
                });
#pragma warning restore 612, 618
        }
    }
}
