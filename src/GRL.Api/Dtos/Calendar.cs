namespace GRL.Api.Dtos;

public class CalendarResponse
{
    public string League { get; set; }
    
    public string Season { get; set; }
    
    public List<Race> Races { get; set; }
}

public record Race(int Round, Location Location, DateTime Date);

public record Location(string Country, string Place);