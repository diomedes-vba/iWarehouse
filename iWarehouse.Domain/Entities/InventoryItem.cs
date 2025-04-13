namespace iWarehouse.Domain.Entities;

public class InventoryItem
{
    public int Id { get; set; }
    public string ProductNumber { get; set; }
    public int Quantity { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? LastUpdatedAt { get; set; }
}