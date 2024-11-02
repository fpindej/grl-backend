namespace GRL.Domain.Entities;

public class Circuit
{
    public int CircuitId { get; }
    public string Country { get; }
    public string Location { get; }

    public Circuit(int circuitId, string name, string location)
    {
        CircuitId = circuitId;
        Country = name ?? throw new ArgumentNullException(nameof(name));
        Location = location ?? throw new ArgumentNullException(nameof(location));
    }
}