namespace InventoryScanner.Inventory.Inventory;
public record InventoryResponse(
    Guid id,
    DateTime LastModified,
    string Name,
    string Date
);