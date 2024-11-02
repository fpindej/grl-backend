using GRL.Domain.Entities;

namespace GRL.Domain.Repositories;

public interface ICalendarRepository
{
    Task<IEnumerable<Race>> GetCalendarAsync(string leagueName, string seasonName);
}