namespace GRL.Domain.Entities;

public class Circuit
{
    public int Id { get; }
    public string Country { get; }
    public string Location { get; }

    public Circuit(int id, string name, string location)
    {
        Id = id;
        Country = name ?? throw new ArgumentNullException(nameof(name));
        Location = location ?? throw new ArgumentNullException(nameof(location));
    }
}