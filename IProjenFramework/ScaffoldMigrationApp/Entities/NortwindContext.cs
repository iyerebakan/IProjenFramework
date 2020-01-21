using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ScaffoldConsoleApp.Entities
{
    public partial class NortwindContext : DbContext
    {
        public NortwindContext()
        {
        }

        public NortwindContext(DbContextOptions<NortwindContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cities> Cities { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<CustomerAddresses> CustomerAddresses { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Districts> Districts { get; set; }
        public virtual DbSet<OperationClaims> OperationClaims { get; set; }
        public virtual DbSet<UserOperationClaims> UserOperationClaims { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=ProjenFrameworkDb;User ID=sa;Password=#1q2w3e#");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cities>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("IX_Cities");

                entity.HasIndex(e => new { e.CountryId, e.Name })
                    .HasName("IX_Cities_CountyId")
                    .IsUnique();

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cities_Countries");
            });

            modelBuilder.Entity<Countries>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("IX_Countries");
            });

            modelBuilder.Entity<CustomerAddresses>(entity =>
            {
                entity.HasOne(d => d.City)
                    .WithMany(p => p.CustomerAddresses)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_CustomerAddresses_Cities");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.CustomerAddresses)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_CustomerAddresses_Countries");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerAddresses)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerAddresses_Customers");

                entity.HasOne(d => d.District)
                    .WithMany(p => p.CustomerAddresses)
                    .HasForeignKey(d => d.DistrictId)
                    .HasConstraintName("FK_CustomerAddresses_Districts");
            });

            modelBuilder.Entity<Districts>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("IX_Districts");

                entity.HasIndex(e => new { e.CityId, e.Name })
                    .HasName("IX_Districts_CityId")
                    .IsUnique();

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Districts)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Districts_Cities");
            });

            modelBuilder.Entity<UserOperationClaims>(entity =>
            {
                entity.HasIndex(e => e.OperationClaimId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
