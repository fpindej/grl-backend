using GRL.Application.Services;
using GRL.Domain.Entities;
using GRL.Domain.Repositories;

namespace GRL.Infrastructure.Services;

internal class CalendarService : ICalendarService
{
    private readonly ICalendarRepository _calendarRepository;

    public CalendarService(ICalendarRepository calendarRepository)
    {
        _calendarRepository = calendarRepository;
    }

    public async Task<List<Race>> GetCalendarAsync(string leagueName, string seasonName)
    {
        var races = (await _calendarRepository.GetCalendarAsync(leagueName, seasonName)).ToList();
        return races;
    }
}