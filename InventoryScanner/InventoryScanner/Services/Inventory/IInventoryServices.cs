using InventoryScanner.Models;
namespace InventoryScanner.Services.Inventory;

public interface IInventoryServices{
    void CreateInventory(InventoryModel inventory);
    void DeleteInventory(Guid id);
    InventoryModel GetInventory(Guid id);
    void UpsertInvenotory(InventoryModel inventory);
}