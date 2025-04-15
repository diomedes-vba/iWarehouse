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
        await _inventoryRepository.UpdateItemAsync(inventoryItem);
    }

    public async Task DeleteInventoryItemAsync(string productNumber)
    {
        await _inventoryRepository.DeleteItemAsync(productNumber);
    }
}