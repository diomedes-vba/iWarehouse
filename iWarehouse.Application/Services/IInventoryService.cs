using iWarehouse.Domain.Entities;

namespace iWarehouse.Application.Services;

public interface IInventoryService
{
    Task<InventoryItem> GetInventoryItemAsync(string productNumber);
    Task AddInventoryItemAsync(InventoryItem item);
    Task UpdateInventoryItemAsync(InventoryItem item);
    Task DeleteInventoryItemAsync(string productNumber);
    Task<IEnumerable<InventoryItem>> GetBatchInventoryItemsAsync(string[] productNumbers);
}