using iWarehouse.Domain.Entities;
using iWarehouse.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace iWarehouse.Infrastructure.Persistence;

public class InventoryRepository : IInventoryRepository
{
    private readonly InventoryDbContext _context;

    public InventoryRepository(InventoryDbContext context)
    {
        _context = context;
    }
    
    public async Task<InventoryItem> GetInventoryItemByProductNumberAsync(string productNumber)
    {
        return await _context.InventoryItems.FirstOrDefaultAsync(i => i.ProductNumber == productNumber);
    }

    public async Task AddItemAsync(InventoryItem item)
    {
        await _context.InventoryItems.AddAsync(item);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateItemAsync(InventoryItem item)
    {
        _context.InventoryItems.Update(item);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteItemAsync(string productNumber)
    {
        var itemToRemove = await _context.InventoryItems.FirstOrDefaultAsync(i => i.ProductNumber == productNumber);
        if (itemToRemove != null)
        {
            _context.InventoryItems.Remove(itemToRemove);
        }
    }

    public async Task<IEnumerable<InventoryItem>> GetBatchInventoryItemsAsync(string[] productNumbers)
    {
        return await _context.InventoryItems.Where(i => productNumbers.Contains(i.ProductNumber)).ToListAsync();
    }
}