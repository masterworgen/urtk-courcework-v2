using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace urtk_courcework_v2
{
    public partial class groceryContext : DbContext
    {
        public groceryContext()
        {
        }

        public groceryContext(DbContextOptions<groceryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Dictionary> Dictionary { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Provider> Provider { get; set; }
        public virtual DbSet<Sale> Sale { get; set; }
        public virtual DbSet<Waybill> Waybill { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-80TT6SQ\\SQLEXPRESS;Database=grocery;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Dictionary>(entity =>
            {
                entity.HasKey(e => e.IdDictionary);

                entity.Property(e => e.NameDictionary)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.IdProduct);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.ShelfLifeProduct).HasColumnType("date");

                entity.HasOne(d => d.IdDictionaryNavigation)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.IdDictionary)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Dictionary");

                entity.HasOne(d => d.IdWaybillNavigation)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.IdWaybill)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Waybill");
            });

            modelBuilder.Entity<Provider>(entity =>
            {
                entity.HasKey(e => e.IdProvider);

                entity.Property(e => e.CityProvider)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DenomintaionProvider)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NameProvider)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PatronymicProvider)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SurnameProvider)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.HasKey(e => e.IdSale);

                entity.Property(e => e.DataSale).HasColumnType("date");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.Sale)
                    .HasForeignKey(d => d.IdProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sale_Product");
            });

            modelBuilder.Entity<Waybill>(entity =>
            {
                entity.HasKey(e => e.IdWaybill);

                entity.Property(e => e.IdData).HasColumnType("date");

                entity.HasOne(d => d.IdProviderNavigation)
                    .WithMany(p => p.Waybill)
                    .HasForeignKey(d => d.IdProvider)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Waybill_Provider");
            });
        }
    }
}
