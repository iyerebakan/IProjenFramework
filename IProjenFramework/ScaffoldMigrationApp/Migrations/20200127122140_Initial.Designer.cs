﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ScaffoldMigrationApp.Entities;

namespace ScaffoldMigrationApp.Migrations
{
    [DbContext(typeof(NortwindContext))]
    [Migration("20200127122140_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ScaffoldMigrationApp.Entities.Cities", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .HasName("IX_Cities");

                    b.HasIndex("CountryId", "Name")
                        .IsUnique()
                        .HasName("IX_Cities_CountyId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("ScaffoldMigrationApp.Entities.Countries", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("IX_Countries");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("ScaffoldMigrationApp.Entities.CustomerAddresses", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<int?>("CountryId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int?>("DistrictId")
                        .HasColumnType("int");

                    b.Property<string>("FullAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(225)")
                        .HasMaxLength(225);

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("CountryId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DistrictId");

                    b.ToTable("CustomerAddresses");
                });

            modelBuilder.Entity("ScaffoldMigrationApp.Entities.Customers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreateUser")
                        .HasColumnType("int");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FaxNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Identifier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaxNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaxOffice")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdateUser")
                        .HasColumnType("int");

                    b.Property<string>("Web")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("ScaffoldMigrationApp.Entities.DesignGroupDetails", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("DesignGroupId")
                        .HasColumnType("int");

                    b.Property<int>("FormId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FormId");

                    b.HasIndex("DesignGroupId", "FormId")
                        .IsUnique()
                        .HasName("IX_FormId_DesignGroupId");

                    b.ToTable("DesignGroupDetails");
                });

            modelBuilder.Entity("ScaffoldMigrationApp.Entities.DesignGroups", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(225)")
                        .HasMaxLength(225);

                    b.Property<int?>("DesignGroupMasterId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("DesignGroupMasterId");

                    b.ToTable("DesignGroups");
                });

            modelBuilder.Entity("ScaffoldMigrationApp.Entities.Districts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .HasName("IX_Districts");

                    b.HasIndex("CityId", "Name")
                        .IsUnique()
                        .HasName("IX_Districts_CityId");

                    b.ToTable("Districts");
                });

            modelBuilder.Entity("ScaffoldMigrationApp.Entities.Forms", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<bool>("Locked")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Forms");
                });

            modelBuilder.Entity("ScaffoldMigrationApp.Entities.OperationClaims", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OperationClaims");
                });

            modelBuilder.Entity("ScaffoldMigrationApp.Entities.UserOperationClaims", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OperationClaimId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OperationClaimId");

                    b.HasIndex("UserId");

                    b.ToTable("UserOperationClaims");
                });

            modelBuilder.Entity("ScaffoldMigrationApp.Entities.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasName("IX_Users")
                        .HasFilter("[Email] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ScaffoldMigrationApp.Entities.Cities", b =>
                {
                    b.HasOne("ScaffoldMigrationApp.Entities.Countries", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .HasConstraintName("FK_Cities_Countries")
                        .IsRequired();
                });

            modelBuilder.Entity("ScaffoldMigrationApp.Entities.CustomerAddresses", b =>
                {
                    b.HasOne("ScaffoldMigrationApp.Entities.Cities", "City")
                        .WithMany("CustomerAddresses")
                        .HasForeignKey("CityId")
                        .HasConstraintName("FK_CustomerAddresses_Cities");

                    b.HasOne("ScaffoldMigrationApp.Entities.Countries", "Country")
                        .WithMany("CustomerAddresses")
                        .HasForeignKey("CountryId")
                        .HasConstraintName("FK_CustomerAddresses_Countries");

                    b.HasOne("ScaffoldMigrationApp.Entities.Customers", "Customer")
                        .WithMany("CustomerAddresses")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK_CustomerAddresses_Customers")
                        .IsRequired();

                    b.HasOne("ScaffoldMigrationApp.Entities.Districts", "District")
                        .WithMany("CustomerAddresses")
                        .HasForeignKey("DistrictId")
                        .HasConstraintName("FK_CustomerAddresses_Districts");
                });

            modelBuilder.Entity("ScaffoldMigrationApp.Entities.DesignGroupDetails", b =>
                {
                    b.HasOne("ScaffoldMigrationApp.Entities.DesignGroups", "DesignGroup")
                        .WithMany("DesignGroupDetails")
                        .HasForeignKey("DesignGroupId")
                        .HasConstraintName("FK_DesignGroupDetails_DesignGroups")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ScaffoldMigrationApp.Entities.Forms", "Form")
                        .WithMany("DesignGroupDetails")
                        .HasForeignKey("FormId")
                        .HasConstraintName("FK_DesignGroupDetails_Forms")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ScaffoldMigrationApp.Entities.DesignGroups", b =>
                {
                    b.HasOne("ScaffoldMigrationApp.Entities.DesignGroups", "DesignGroupMaster")
                        .WithMany("InverseDesignGroupMaster")
                        .HasForeignKey("DesignGroupMasterId")
                        .HasConstraintName("FK_DesignGroups_DesignGroups");
                });

            modelBuilder.Entity("ScaffoldMigrationApp.Entities.Districts", b =>
                {
                    b.HasOne("ScaffoldMigrationApp.Entities.Cities", "City")
                        .WithMany("Districts")
                        .HasForeignKey("CityId")
                        .HasConstraintName("FK_Districts_Cities")
                        .IsRequired();
                });

            modelBuilder.Entity("ScaffoldMigrationApp.Entities.UserOperationClaims", b =>
                {
                    b.HasOne("ScaffoldMigrationApp.Entities.OperationClaims", "OperationClaim")
                        .WithMany("UserOperationClaims")
                        .HasForeignKey("OperationClaimId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ScaffoldMigrationApp.Entities.Users", "User")
                        .WithMany("UserOperationClaims")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_UserOperationClaims_Users")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}