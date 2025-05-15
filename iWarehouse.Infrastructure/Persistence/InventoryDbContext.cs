using iWarehouse.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace iWarehouse.Infrastructure;

public class InventoryDbContext : DbContext
{
    public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options) { }
    
    public DbSet<InventoryItem> InventoryItems { get; set; }
    public DbSet<StockTransaction> StockTransactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<InventoryItem>(entity =>
        {
            entity.HasKey(i => i.Id);
            entity.HasAlternateKey(i => i.ProductNumber);

            entity.Property(i => i.ProductNumber)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(i => i.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
        });

        modelBuilder.Entity<StockTransaction>(entity =>
        {
            entity.HasKey(st => st.Id);
            
            entity.Property(i => i.ProductNumber)
                .IsRequired()
                .HasMaxLength(100);
            
            entity.HasOne(st => st.InventoryItem)
                .WithMany(i => i.StockTransactions)
                .HasForeignKey(st => st.ProductNumber)
                .HasPrincipalKey(i => i.ProductNumber)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }
}