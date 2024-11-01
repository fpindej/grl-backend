namespace GRL.Domain.Entities;

public class Race
{
    public int RaceId { get; }
    public int Round { get; }
    public DateTime Date { get; }
    public Circuit Circuit { get; }
    public Season Season { get; }

    private readonly List<RaceResult> _raceResults = new();
    public IReadOnlyCollection<RaceResult> RaceResults => _raceResults.AsReadOnly();

    public Race(int raceId, int round, DateTime date, Circuit circuit, Season season)
    {
        RaceId = raceId;
        Round = round;
        Date = date;
        Circuit = circuit ?? throw new ArgumentNullException(nameof(circuit));
        Season = season ?? throw new ArgumentNullException(nameof(season));
    }

    public void AddRaceResult(RaceResult raceResult)
    {
        if (raceResult == null) throw new ArgumentNullException(nameof(raceResult));

        // Business rule: A driver cannot have more than one result in the same race.
        if (_raceResults.Any(rr => rr.Driver.DriverId == raceResult.Driver.DriverId))
            throw new InvalidOperationException("Driver already has a result for this race.");

        _raceResults.Add(raceResult);
    }

    public void RecalculateResults()
    {
        // Recalculate positions based on total times (including penalties)
        var orderedResults = _raceResults.OrderBy(rr => rr.TotalTime).ToList();

        for (var i = 0; i < orderedResults.Count; i++) orderedResults[i].SetPosition(i + 1);
    }
}