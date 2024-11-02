namespace GRL.Domain.Entities;

public class DriverTeamAssignment
{
    public int AssignmentId { get; }
    public Driver Driver { get; }
    public Team Team { get; }
    public DateTime StartDate { get; }
    public DateTime? EndDate { get; private set; } // Null means current assignment

    public DriverTeamAssignment(int assignmentId, Driver driver, Team team, DateTime startDate, DateTime? endDate = null)
    {
        AssignmentId = assignmentId;
        Driver = driver ?? throw new ArgumentNullException(nameof(driver));
        Team = team ?? throw new ArgumentNullException(nameof(team));
        StartDate = startDate;
        EndDate = endDate;
    }

    public void EndAssignment(DateTime endDate)
    {
        if (EndDate.HasValue)
            throw new InvalidOperationException("Assignment already ended.");

        if (endDate <= StartDate)
            throw new ArgumentException("End date must be after start date.");

        EndDate = endDate;
    }

    public bool IsActiveOn(DateTime date)
    {
        return date >= StartDate && (EndDate == null || date <= EndDate.Value);
    }
}