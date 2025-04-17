using iWarehouse.Domain.Entities;
using iWarehouse.Domain.Interfaces;

namespace iWarehouse.Application.Services;

public class InventoryService : IInventoryService
{
    private readonly IInventoryRepository _inventoryRepository;

    public InventoryService(IInventoryRepository inventoryRepository)
    {
        _inventoryRepository = inventoryRepository;
    }

    public async Task<InventoryItem> GetInventoryItemAsync(string productNumber)
    {
        return await _inventoryRepository.GetInventoryItemByProductNumberAsync(productNumber);
    }

    public async Task AddInventoryItemAsync(InventoryItem inventoryItem)
    {
        await _inventoryRepository.AddItemAsync(inventoryItem);
    }

    public async Task UpdateInventoryItemAsync(InventoryItem inventoryItem)
    {
        var itemToUpdate = await _inventoryRepository.GetInventoryItemByProductNumberAsync(inventoryItem.ProductNumber);

        if (itemToUpdate != null)
        {
            itemToUpdate.Quantity = inventoryItem.Quantity;
            itemToUpdate.LastUpdatedAt = inventoryItem.LastUpdatedAt;
            await _inventoryRepository.UpdateItemAsync(inventoryItem);
        }
    }

    public async Task DeleteInventoryItemAsync(string productNumber)
    {
        await _inventoryRepository.DeleteItemAsync(productNumber);
    }

    public async Task<IEnumerable<InventoryItem>> GetBatchInventoryItemsAsync(string[] productNumbers)
    {
        return await _inventoryRepository.GetBatchInventoryItemsAsync(productNumbers);
    }
}