namespace GRL.Domain.Entities;

public class Team
{
    public int Id { get; }
    public string Name { get; }

    private readonly List<Driver> _drivers = [];
    public IReadOnlyCollection<Driver> Drivers => _drivers.AsReadOnly();

    public Team(int id, string name)
    {
        Id = id;
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public void AddDriver(Driver driver)
    {
        if (driver == null) throw new ArgumentNullException(nameof(driver));

        // Business rule: Each team must have exactly two main drivers.
        if (_drivers.Count >= 2)
            throw new InvalidOperationException("A team cannot have more than two drivers.");

        _drivers.Add(driver);
    }
}