namespace GRL.Domain.Entities;

public class Driver
{
    public int Id { get; }
    public string Name { get; }
    public int PenaltyPoints { get; private set; }

    private readonly List<DriverTeamAssignment> _teamAssignments = [];
    public IReadOnlyCollection<DriverTeamAssignment> TeamAssignments => _teamAssignments.AsReadOnly();

    public Driver(int id, string name)
    {
        Id = id;
        Name = name ?? throw new ArgumentNullException(nameof(name));
        PenaltyPoints = 0;
    }

    public void AddTeamAssignment(DriverTeamAssignment assignment)
    {
        if (assignment == null) throw new ArgumentNullException(nameof(assignment));

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
        PenaltyPoints += points;
    }
}