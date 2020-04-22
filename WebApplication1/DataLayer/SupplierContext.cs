using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataLayer
{
    public partial class SupplierContext : DbContext
    {
        public SupplierContext()
        {
        }

        public SupplierContext(DbContextOptions<SupplierContext> options) : base(options)
        {
        }

        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<Tights> Tights { get; set; }
        public virtual DbSet<Buyer> Buyer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Supplier>(entity =>
                {
                    entity.Property(c => c.Id).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
                    entity.Property(c => c.Name).IsRequired();
                    entity.Property(c => c.Address).IsRequired();
                });

            modelBuilder.Entity<Buyer>(entity =>
                {
                    entity.Property(m => m.Id).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
                    entity.Property(m => m.Name).IsRequired();
                   
                });

            modelBuilder.Entity<Tights>(entity =>
                {
                    entity.Property(s=>s.Id).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
                    entity.Property(s => s.Date).IsRequired();
                    entity.Property(s => s.Size).IsRequired();
                    entity.HasOne(s => s.Supplier)
                        .WithMany(c => c.Tights)
                        .HasForeignKey(s => s.SupplierId)
                        .HasConstraintName("FK_Tights_Supplier");
                    entity.HasOne(s => s.Buyer)
                        .WithMany(m => m.Tightss).HasForeignKey(s=>s.BuyerId)
                        .HasConstraintName("FK_Tights_Buyer");
                });
            
            this.OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}