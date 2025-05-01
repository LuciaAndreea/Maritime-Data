//class for Voyages table from db
public class Voyage{
    public int Id {get; set;}
    public DateTime VoyageData {get; set;}
    public int ShipId {get; set;}
    public required string DeparturePortName {get; set;}
    public required string ArrivalPortName {get; set;}
    public DateTime StartDate {get; set;}
    public DateTime EndDate {get; set;}
}