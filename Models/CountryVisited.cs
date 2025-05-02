using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.SignalR;
//class for CountriVisited table from db
public class CountryVisited{
    [Column("id")]
    public int Id {get; set;}
    [Column("countryid")]
    public int CountryId {get; set;}
    [Column("visitdate")]
    public DateTime VisitDate {get; set;}
    [Column("countryname")]
    public required string CountryName{get; set;}
    
}