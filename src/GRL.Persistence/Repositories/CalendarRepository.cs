using GRL.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace GRL.Persistence.Repositories;

public class CalendarRepository
{
    private readonly GrlDbContext _context;

    public CalendarRepository(GrlDbContext context)
    {
        _context = context;
    }

    public async Task<List<Race>> GetCalendarAsync(string leagueName, string seasonName)
    {
        return await _context.Races
            .Include(r => r.Circuit)
            .Include(r => r.League)
            .Include(r => r.Season)
            .Where(r => r.League.Name.Equals(leagueName, StringComparison.OrdinalIgnoreCase)
                        && r.Season.Name.Equals(seasonName, StringComparison.OrdinalIgnoreCase))
            .OrderBy(r => r.Round)
            .ToListAsync();
    }
}