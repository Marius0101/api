using Microsoft.AspNetCore.Mvc;
using InventoryScanner.Inventory.Inventory;
using InventoryScanner.Models;
using InventoryScanner.Services.Inventory;

namespace InventoryScanner.Controllers;
[ApiController] 
[Route("{controller}")]
public class InventryController : ControllerBase{
    private readonly IInventoryServices _inventoryServices;
    public InventryController(IInventoryServices inventoryServices ){
        _inventoryServices = inventoryServices;
    }
    [HttpPost("/inventory")]
    public IActionResult CreateInventory(CreateInventoryRequest request){
        var inventory = new InventoryModel(
            Guid.NewGuid(),
            DateTime.UtcNow,
            request.Name,
            request.Date

        );
        
        _inventoryServices.CreateInventory(inventory); // conexiunea la baza de date

        var response  = new InventoryResponse(
            inventory.Id,
            inventory.LastModified,
            inventory.Name,
            inventory.Date
        );
        return  CreatedAtAction(
            actionName : nameof(GetInventory),
            routeValues :new {id = inventory.Id},
            response
        );
    }

    [HttpGet("/inventory/{id:guid}")]
    public IActionResult GetInventory(Guid id){
        InventoryModel inventory = _inventoryServices.GetInventory(id);
        var response = new InventoryResponse(
            inventory.Id,
            inventory.LastModified,
            inventory.Name,
            inventory.Date
        );
        return  Ok(response);
    }

    [HttpPut("/inventory/{id:guid}")]
    public IActionResult UpsertInventory(Guid id, UpsertInventoryRequest request){
        
        var response = new InventoryModel(
            id,
            DateTime.UtcNow,
            request.Name,
            request.Date
        );
        // TODO: returneaza 201 daca ai primit un update/modificare
        _inventoryServices.UpsertInvenotory(response);
        return  NoContent();
    }

    [HttpDelete("/inventory{id:guid}")]
    public IActionResult DeleteInventory(Guid id){
        _inventoryServices.DeleteInventory(id);
        return  NoContent();
    }
}