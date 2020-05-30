using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PointOfSale.Api.Models
{
    public partial class PointOfSaleContext : DbContext
    {
        public PointOfSaleContext()
        {
        }

        public PointOfSaleContext(DbContextOptions<PointOfSaleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Applications> Applications { get; set; }
        public virtual DbSet<UserTypes> UserTypes { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=<Server Name>;Database=<DB Name>;Integrated Security=False;User ID=<username>;Password=<password>");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Applications>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApplicationLoggedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ApplicationLoggedInDate).HasColumnType("datetime");

                entity.Property(e => e.ApplicationNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ApplicationStatus)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CardDeliveryStatus)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserTypes>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.UserTypeDescription)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.Userid)
                    .HasName("PK__Users__7B9E7F3521E230AE");

                entity.Property(e => e.Userid).HasColumnName("USERID");

                entity.Property(e => e.Mobilenumber)
                    .HasColumnName("MOBILENUMBER")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Usertype)
                    .HasColumnName("USERTYPE")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
