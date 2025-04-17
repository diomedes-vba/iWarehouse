using iWarehouse.Domain.Entities;

namespace iWarehouse.Domain.Interfaces;

public interface IInventoryRepository
{
    Task<InventoryItem> GetInventoryItemByProductNumberAsync(string productNumber);
    Task AddItemAsync(InventoryItem item);
    Task UpdateItemAsync(InventoryItem item);
    Task DeleteItemAsync(string productNumber);
    Task<IEnumerable<InventoryItem>> GetBatchInventoryItemsAsync(string[] productNumbers);
}