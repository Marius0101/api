namespace InventoryScanner.Models;

public class InventoryModel{

    public Guid Id {get;}
    public DateTime LastModified { get;}
    public string Name {get;}
    public string Date {get;}
    
    public InventoryModel(
        Guid id,
        DateTime lastModified,
        string name,
        string date
    ){
        Id = id;
        LastModified = lastModified;
        Name = name;
        Date = date;
    }
}