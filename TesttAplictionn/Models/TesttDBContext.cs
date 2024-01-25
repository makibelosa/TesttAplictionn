using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TesttAplictionn.Models
{
    public partial class TesttDBContext : DbContext
    {
        public TesttDBContext()
        {
        }

        public TesttDBContext(DbContextOptions<TesttDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=TesttDB;Username=postgres;Password=Pedmond@63");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasKey(e => e.BookId)
                    .HasName("Booking_pkey");

                entity.ToTable("Booking");

                entity.Property(e => e.BookLocation)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.BookName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Booking1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Booking");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.Addreess)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Age)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Idnumber)
                    .IsRequired()
                    .HasMaxLength(13)
                    .HasColumnName("IDnumber");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.ToTable("Gender");

                entity.Property(e => e.Gender1)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("Gender");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.OrderDate).HasColumnType("date");

                entity.Property(e => e.OrderName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.OrderStatus)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.ToTable("Province");

                entity.Property(e => e.ProvinceId).HasColumnName("ProvinceID");

                entity.Property(e => e.Province1)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("Province");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
