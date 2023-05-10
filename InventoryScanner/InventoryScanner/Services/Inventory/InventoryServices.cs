using InventoryScanner.Models;

namespace InventoryScanner.Services.Inventory;

public class InventoryServices : IInventoryServices
{
    private readonly  static Dictionary< Guid, InventoryModel>  _inventory = new();
    public void CreateInventory(InventoryModel inventory)
    {
        _inventory.Add(inventory.Id, inventory);
    }

    public void DeleteInventory(Guid id)
    {
       _inventory.Remove(id);
    }

    public InventoryModel GetInventory(Guid id)
    {
        return _inventory[id];
    }

    public void UpsertInvenotory(InventoryModel inventory)
    {
        _inventory[inventory.Id] = inventory;
    }
}