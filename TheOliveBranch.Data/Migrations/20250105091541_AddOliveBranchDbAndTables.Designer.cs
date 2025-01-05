﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TheOliveBranch.Data;

#nullable disable

namespace TheOliveBranch.Data.Migrations
{
    [DbContext(typeof(OliveBranchDbContext))]
    [Migration("20250105091541_AddOliveBranchDbAndTables")]
    partial class AddOliveBranchDbAndTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TheOliveBranch.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("NVARCHAR")
                        .HasColumnOrder(2);

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("INT")
                        .HasColumnOrder(3);

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("TheOliveBranch.Models.FoodType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("NVARCHAR")
                        .HasColumnOrder(2);

                    b.HasKey("Id");

                    b.ToTable("FoodType");
                });

            modelBuilder.Entity("TheOliveBranch.Models.MenuItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("INT")
                        .HasColumnOrder(8);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR")
                        .HasColumnOrder(3);

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("INT")
                        .HasColumnOrder(6);

                    b.Property<int>("FoodTypeId")
                        .HasColumnType("INT")
                        .HasColumnOrder(7);

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(255)")
                        .HasColumnOrder(4);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("NVARCHAR")
                        .HasColumnOrder(2);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10,2)")
                        .HasColumnOrder(5);

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("FoodTypeId");

                    b.ToTable("MenuItems");
                });

            modelBuilder.Entity("TheOliveBranch.Models.MenuItem", b =>
                {
                    b.HasOne("TheOliveBranch.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TheOliveBranch.Models.FoodType", "FoodType")
                        .WithMany()
                        .HasForeignKey("FoodTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("FoodType");
                });
#pragma warning restore 612, 618
        }
    }
}