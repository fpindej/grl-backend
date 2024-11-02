using GRL.Domain.Entities;
using GRL.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GRL.Persistence.Repositories;

internal class CalendarRepository : ICalendarRepository
{
    private readonly GrlDbContext _context;

    public CalendarRepository(GrlDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Race>> GetCalendarAsync(string leagueName, string seasonName)
    {
        var races = await _context.Races
            .Include(r => r.Circuit)
            .Include(r => r.Season)
            .ThenInclude(s => s.League)
            .Where(r => EF.Functions.ILike(r.Season.League.Name, leagueName)
                        && EF.Functions.ILike(r.Season.Name, seasonName))
            .OrderBy(r => r.Round)
            .ToListAsync();

        var domainRaces = races.Select(ToDomain).ToList();

        return domainRaces;
    }

    private static Race ToDomain(Models.Race race)
    {
        var circuit = new Circuit(
            id: race.Circuit.Id,
            name: race.Circuit.Country,
            location: race.Circuit.Location);

        var season = new Season(
            id: race.Season.Id,
            name: race.Season.Name);

        var domainRace = new Race(
            id: race.Id,
            round: race.Round,
            date: race.Date,
            circuit: circuit,
            season: season);

        return domainRace;
    }
}