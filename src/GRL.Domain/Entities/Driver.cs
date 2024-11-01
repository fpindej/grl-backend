namespace GRL.Domain.Entities;

public class Driver
{
    public int DriverId { get; }
    public string Name { get; }
    public int PenaltyPoints { get; private set; } // Accumulated penalty points

    private readonly List<League> _reserveLeagues = new();
    public IReadOnlyCollection<League> ReserveLeagues => _reserveLeagues.AsReadOnly();

    public Driver(int driverId, string name)
    {
        DriverId = driverId;
        Name = name ?? throw new ArgumentNullException(nameof(name));
        PenaltyPoints = 0;
    }

    public void AddReserveLeague(League league)
    {
        if (league == null) throw new ArgumentNullException(nameof(league));

        if (_reserveLeagues.Any(l => l.LeagueId == league.LeagueId))
            throw new InvalidOperationException("Driver is already a reserve driver in this league.");

        _reserveLeagues.Add(league);
    }

    public void AddPenaltyPoints(int points)
    {
        PenaltyPoints += points;
        // Implement logic for qualification or race bans if needed
    }
}