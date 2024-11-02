namespace GRL.Domain.Entities;

public class League
{
    public int LeagueId { get; }
    public string Name { get; }

    private readonly List<Team> _teams = [];
    public IReadOnlyCollection<Team> Teams => _teams.AsReadOnly();

    private readonly List<Season> _seasons = [];
    public IReadOnlyCollection<Season> Seasons => _seasons.AsReadOnly();

    public League(int leagueId, string name)
    {
        LeagueId = leagueId;
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public void AddTeam(Team team)
    {
        if (team == null) throw new ArgumentNullException(nameof(team));

        // Business rule: Each league has up to 10 teams
        if (_teams.Count >= 10)
            throw new InvalidOperationException("A league cannot have more than 10 teams.");

        _teams.Add(team);
    }

    public void AddSeason(Season season)
    {
        if (season == null) throw new ArgumentNullException(nameof(season));

        // Ensure no duplicate seasons
        if (_seasons.Any(s => s.SeasonId == season.SeasonId))
            throw new InvalidOperationException("Season already exists in the league.");

        _seasons.Add(season);
    }
}