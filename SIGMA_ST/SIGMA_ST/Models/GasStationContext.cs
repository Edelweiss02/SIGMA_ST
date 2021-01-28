using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SIGMA_ST.Models
{
    public partial class GasStationContext : DbContext
    {
        public GasStationContext()
        {
        }

        public GasStationContext(DbContextOptions<GasStationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DiscountCard> DiscountCards { get; set; }
        public virtual DbSet<Ga> Gas { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-O2S549V\\SQLEXPRESS;Database=GasStation;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<DiscountCard>(entity =>
            {
                entity.HasKey(e => e.Idcard)
                    .HasName("PK__Discount__43A2A4E2690D9735");

                entity.ToTable("DiscountCard");

                entity.Property(e => e.Idcard).HasColumnName("IDCard");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ga>(entity =>
            {
                entity.HasKey(e => e.Idgas)
                    .HasName("PK__Gas__949199E00F6A78CB");

                entity.Property(e => e.Idgas).HasColumnName("IDGas");

                entity.Property(e => e.NameGas)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasKey(e => e.Idchange)
                    .HasName("PK__Invoice__031C856F78F7173A");

                entity.ToTable("Invoice");

                entity.Property(e => e.Idchange).HasColumnName("IDChange");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.EventType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Idgas).HasColumnName("IDGas");

                entity.HasOne(d => d.IdgasNavigation)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.Idgas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Invoice__IDGas__286302EC");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Idorder)
                    .HasName("PK__Orders__5CBBCADBD1091BF3");

                entity.Property(e => e.Idorder).HasColumnName("IDOrder");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Idcard).HasColumnName("IDCard");

                entity.Property(e => e.Idgas).HasColumnName("IDGas");

                entity.HasOne(d => d.IdcardNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Idcard)
                    .HasConstraintName("FK__Orders__IDCard__2C3393D0");

                entity.HasOne(d => d.IdgasNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Idgas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__IDGas__2B3F6F97");
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.HasKey(e => e.Idsale)
                    .HasName("PK__Sale__C6F3BA0B6E5E36DA");

                entity.ToTable("Sale");

                entity.Property(e => e.Idsale).HasColumnName("IDSale");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("End_Date");

                entity.Property(e => e.Idorder).HasColumnName("IDOrder");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("Start_Date");

                entity.HasOne(d => d.IdorderNavigation)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.Idorder)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Sale__IDOrder__2F10007B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
