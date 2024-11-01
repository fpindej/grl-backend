namespace GRL.Domain.Entities;

public class Penalty
{
    public int PenaltyId { get; }
    public PenaltyType Type { get; }
    public string Reason { get; }
    public TimeSpan? TimePenalty { get; }
    public int? PointsDeduction { get; }
    public DateTime AppliedOn { get; }
    public RaceResult RaceResult { get; }

    public Penalty(int penaltyId, PenaltyType type, string reason, RaceResult raceResult, TimeSpan? timePenalty = null,
        int? pointsDeduction = null)
    {
        PenaltyId = penaltyId;
        Type = type;
        Reason = reason ?? throw new ArgumentNullException(nameof(reason));
        RaceResult = raceResult ?? throw new ArgumentNullException(nameof(raceResult));
        AppliedOn = DateTime.UtcNow;

        TimePenalty = timePenalty;
        PointsDeduction = pointsDeduction;

        ApplyPenalty();
    }

    private void ApplyPenalty()
    {
        if (TimePenalty.HasValue) RaceResult.AddTimePenalty(TimePenalty.Value);

        if (PointsDeduction.HasValue)
        {
            RaceResult.DeductPoints(PointsDeduction.Value);
            RaceResult.Driver.AddPenaltyPoints(PointsDeduction.Value);
        }
    }
}

public enum PenaltyType
{
    TimePenalty,
    PointsDeduction
}