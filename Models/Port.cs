using System.ComponentModel.DataAnnotations.Schema;
// class for Ports table from db
public  class Port{
    [Column("id")]
    public int Id {get; set;}
     [Column("name")]
    public required string Name {get; set;}
     [Column("countryid")]
    public required int Country {get; set;}
}