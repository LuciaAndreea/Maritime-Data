using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


//class for Voyages table from db
public class Voyage{
    [Column("id")]
    public int Id {get; set;}

    [Column("voyagedata")]
     public DateTime VoyageData {get; set;}

     [ForeignKey("Ship")]
     [Column("shipid")]
    public int ShipId {get; set;}
    [Column("startdate")]
    public DateTime StartDate {get; set;}
    [Column("enddate")]
    public DateTime EndDate {get; set;}

    [Required]
    [StringLength(100)]
    [Column("departureportname")]
     public required string DeparturePortName {get; set;} = string.Empty;

     [Required]
    [StringLength(100)]
    [Column("arrivalportnames")]
    public required string ArrivalPortName {get; set;} = string.Empty;
}