using iWarehouse.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace iWarehouse.Infrastructure;

public class InventoryDbContext : DbContext
{
    public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options) { }
    
    public DbSet<InventoryItem> InventoryItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<InventoryItem>(entity =>
        {
            entity.HasKey(i => i.Id);

            entity.Property(i => i.ProductNumber).IsRequired().HasMaxLength(100);

            entity.Property(i => i.CreatedAt).HasDefaultValueSql("GETDATE()");
        });
    }
}