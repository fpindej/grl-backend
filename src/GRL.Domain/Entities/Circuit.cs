namespace GRL.Domain.Entities;

public class Circuit
{
    public int CircuitId { get; }
    public string Name { get; }
    public string Location { get; }

    public Circuit(int circuitId, string name, string location)
    {
        CircuitId = circuitId;
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Location = location ?? throw new ArgumentNullException(nameof(location));
    }
}