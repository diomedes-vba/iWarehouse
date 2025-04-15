using iWarehouse.Application.Services;
using iWarehouse.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace iWarehouse.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class InventoryController : ControllerBase
{
    private readonly IInventoryService _inventoryService;

    public InventoryController(IInventoryService inventoryService)
    {
        _inventoryService = inventoryService;
    }
    
    // GET: api/inventory/{productNumber}
    [HttpGet("{productNumber}")]
    public async Task<IActionResult> GetInventoryItem(string productNumber)
    {
        var item = await _inventoryService.GetInventoryItemAsync(productNumber);
        if (item == null)
            return NotFound();

        return Ok(item);
    }
    
    // POST: api/inventory
    [HttpPost]
    public async Task<IActionResult> AddIventoryItem([FromBody] InventoryItem item)
    {
        if (item == null)
            return BadRequest();
        
        item.CreatedAt = DateTime.Now;
        await _inventoryService.AddInventoryItemAsync(item);
        
        return CreatedAtAction(nameof(GetInventoryItem), new { productNumber = item.ProductNumber }, item);
    }
    
    // PUT: api/inventory/{productNumber}
    [HttpPut("{productNumber}")]
    public async Task<IActionResult> UpdateInventoryItem(string productNumber, [FromBody] InventoryItem item)
    {
        if (item == null || item.ProductNumber != productNumber)
            return BadRequest();
        
        item.LastUpdatedAt = DateTime.Now;
        await _inventoryService.UpdateInventoryItemAsync(item);
        return NoContent();
    }
    
    // DELETE: api/inventory/{productNumber}
    [HttpDelete("{productNumber}")]
    public async Task<IActionResult> DeleteInventoryItem(string productNumber)
    {
        await _inventoryService.DeleteInventoryItemAsync(productNumber);
        return NoContent();
    }
    
}