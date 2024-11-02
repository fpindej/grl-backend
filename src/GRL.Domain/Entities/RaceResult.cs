namespace GRL.Domain.Entities;

public class RaceResult
{
    public int Id { get; }
    public Race Race { get; }
    public Driver Driver { get; }
    public Team Team { get; } // Determined based on assignment
    public int Position { get; private set; }
    public int PointsAwarded { get; private set; }
    public TimeSpan TotalTime { get; private set; }
    
    private readonly List<Penalty> _penalties = [];
    public IReadOnlyCollection<Penalty> Penalties => _penalties.AsReadOnly();


    public RaceResult(int id, Race race, Driver driver, int position, int pointsAwarded, TimeSpan totalTime)
    {
        Id = id;
        Race = race ?? throw new ArgumentNullException(nameof(race));
        Driver = driver ?? throw new ArgumentNullException(nameof(driver));
        Position = position;
        PointsAwarded = pointsAwarded;
        TotalTime = totalTime;

        Team = driver.GetTeamAtDate(race.Date) ?? throw new InvalidOperationException("Driver is not assigned to any team on the race date.");
    }
    
    public void AddPenalty(Penalty penalty)
    {
        if (penalty == null) throw new ArgumentNullException(nameof(penalty));
        _penalties.Add(penalty);

        // Recalculate race results after applying the penalty
        Race.RecalculateResults();
    }

    public void AddTimePenalty(TimeSpan timePenalty)
    {
        TotalTime += timePenalty;
    }

    public void DeductPoints(int points)
    {
        PointsAwarded = Math.Max(val1: 0, PointsAwarded - points);
    }

    public void SetPosition(int newPosition)
    {
        Position = newPosition;
    }
}