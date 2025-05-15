namespace iWarehouse.Domain.Entities;

public class StockTransaction
{
    public Guid Id { get; set; }
    public string ProductNumber { get; set; }
    public InventoryItem InventoryItem { get; set; }
    public int QuantityChange { get; set; }
    public DateTime TransactionDate { get; set; }
    public string Reference { get; set; }
    public string PerfomedBy { get; set; }
}