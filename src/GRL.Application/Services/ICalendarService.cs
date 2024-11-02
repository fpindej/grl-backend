using GRL.Domain.Entities;

namespace GRL.Application.Services;

public interface ICalendarService
{
    Task<List<Race>> GetCalendarAsync(string leagueName, string seasonName);
}