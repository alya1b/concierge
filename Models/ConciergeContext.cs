using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ConciergeWebApplication.Models
{
    public partial class ConciergeContext : DbContext
    {
        public ConciergeContext()
        {
        }

        public ConciergeContext(DbContextOptions<ConciergeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Apartment> Apartments { get; set; } = null!;
        public virtual DbSet<Car> Cars { get; set; } = null!;
        public virtual DbSet<CarTenantRelationship> CarTenantRelationships { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<Tenant> Tenants { get; set; } = null!;
        public virtual DbSet<VisitingApplication> VisitingApplications { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server= DESKTOP-ORD2T5Q\\SQLEXPRESS; Database=Concierge; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Apartment>(entity =>
            {
                entity.ToTable("Apartment");

                entity.Property(e => e.ApartmentId).HasColumnName("ApartmentId");

                entity.Property(e => e.Area).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasKey(e => e.Number);

                entity.ToTable("Car");

                entity.Property(e => e.Number)
                    .HasMaxLength(8)
                    .IsFixedLength();

                entity.Property(e => e.Brand).HasMaxLength(50);
            });

            modelBuilder.Entity<CarTenantRelationship>(entity =>
            {
                entity.ToTable("CarTenantRelationship");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Number)
                    .HasMaxLength(8)
                    .IsFixedLength();

                entity.Property(e => e.TenantId).HasColumnName("TenantID");

                entity.HasOne(d => d.NumberNavigation)
                    .WithMany(p => p.CarTenantRelationships)
                    .HasForeignKey(d => d.Number)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CarTenantRelationship_Car");

                entity.HasOne(d => d.Tenant)
                    .WithMany(p => p.CarTenantRelationships)
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CarTenantRelationship_Tenant");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payment");

                entity.Property(e => e.PaymentId).HasColumnName("PaymentID");

                entity.Property(e => e.ApartmentId).HasColumnName("ApartmentID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Sum).HasColumnType("money");

                entity.HasOne(d => d.Apartment)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.ApartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payment_Apartment");
            });

            modelBuilder.Entity<Tenant>(entity =>
            {
                entity.ToTable("Tenant");

                entity.Property(e => e.TenantId).HasColumnName("TenantID");

                entity.Property(e => e.AppartmentId).HasColumnName("AppartmentID");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasOne(d => d.Appartment)
                    .WithMany(p => p.Tenants)
                    .HasForeignKey(d => d.AppartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tenant_Apartment");
            });

            modelBuilder.Entity<VisitingApplication>(entity =>
            {
                entity.HasKey(e => e.ApplicationId);

                entity.ToTable("VisitingApplication");

                entity.Property(e => e.ApplicationId).HasColumnName("ApplicationID");

                entity.Property(e => e.ApartmentId).HasColumnName("ApartmentID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.PeriodEnd).HasColumnType("datetime");

                entity.Property(e => e.PeriodStart).HasColumnType("datetime");

                entity.Property(e => e.Visitor).HasMaxLength(120);

                entity.HasOne(d => d.Apartment)
                    .WithMany(p => p.VisitingApplications)
                    .HasForeignKey(d => d.ApartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VisitingApplication_Apartment");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
