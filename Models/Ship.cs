//class for the Ships table from db

using System.ComponentModel.DataAnnotations.Schema;
public class Ship{  
    [Column("id")]
    public int Id {get; set;}
    [Column("name")]
    public required string Name {get;set;}
     [Column("maxspeed")]
    public double MaxSpeed {get; set;}
}