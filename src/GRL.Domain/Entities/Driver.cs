namespace GRL.Domain.Entities;

public class Driver
{
    private readonly List<DriverTeamAssignment> _teamAssignments = new();

    public Driver(string firstName, string lastName)
    {
        FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
        LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
    }

    public int Id { get; set; }

    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public int PenaltyPoints { get; private set; }

    public IReadOnlyCollection<DriverTeamAssignment> TeamAssignments => _teamAssignments.AsReadOnly();

    public void AddTeamAssignment(DriverTeamAssignment assignment)
    {
        if (assignment == null)
            throw new ArgumentNullException(nameof(assignment));

        if (_teamAssignments.Any(a => a.IsActiveOn(assignment.StartDate) ||
                                      (assignment.EndDate.HasValue && a.IsActiveOn(assignment.EndDate.Value))))
            throw new InvalidOperationException("Driver already has an assignment during this period.");

        _teamAssignments.Add(assignment);
    }

    public Team? GetTeamAtDate(DateTime date)
    {
        var assignment = _teamAssignments.FirstOrDefault(a => a.IsActiveOn(date));
        return assignment?.Team;
    }

    public void AddPenaltyPoints(int points)
    {
        if (points < 0)
            throw new ArgumentOutOfRangeException(nameof(points), "Points cannot be negative.");

        PenaltyPoints += points;
    }
}