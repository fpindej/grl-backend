namespace GRL.Domain.Entities;

public class Season
{
    public int SeasonId { get; }
    public string Name { get; }

    private readonly List<Race> _races = new();
    public IReadOnlyCollection<Race> Races => _races.AsReadOnly();

    public Season(int seasonId, string name)
    {
        SeasonId = seasonId;
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public void AddRace(Race race)
    {
        if (race == null) throw new ArgumentNullException(nameof(race));

        // Business rules:
        // - No two races in the same season should have the same round number.
        // - Races should not be scheduled on the same date.
        if (_races.Any(r => r.Round == race.Round))
            throw new InvalidOperationException($"A race with round {race.Round} already exists in the season.");

        if (_races.Any(r => r.Date.Date == race.Date.Date))
            throw new InvalidOperationException($"A race is already scheduled on {race.Date.ToShortDateString()}.");

        _races.Add(race);
    }
}