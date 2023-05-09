using Microsoft.AspNetCore.Mvc;
using InventoryScanner.Inventory.Inventory;
using InventoryScanner.Models;

namespace InventoryScanner.Controllers;
[ApiController] 
[Route("[controller]")]
public class InventryController : ControllerBase{

    [HttpPost()]
    public IActionResult CreateInventory(CreateInventoryRequest request){
        var inventory = new InventoryModel(
            Guid.NewGuid(),
            DateTime.UtcNow,
            request.Name,
            request.Date

        );
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

    [HttpGet("/{id:guid}")]
    public IActionResult GetInventory(Guid id){
        return  Ok(id);
    }

    [HttpPut("/{id:guid}")]
    public IActionResult UpsertInventory(Guid id, UpsertInventoryRequest request){
        return  Ok(request);
    }

    [HttpDelete("/{id:guid}")]
    public IActionResult DeleteInventory(Guid id){
        return  Ok(id);
    }
}