using System.ComponentModel;
using GRL.Api.Dtos;
using GRL.Application.Services;

namespace GRL.Api.Controllers;

using Microsoft.AspNetCore.Mvc;

[Route("[controller]")]
[ApiController]
public class CalendarController : ControllerBase
{
    private readonly ICalendarService _calendarService;
    private readonly ILogger<CalendarController> _logger;

    public CalendarController(ICalendarService calendarService, ILogger<CalendarController> logger)
    {
        _calendarService = calendarService;
        _logger = logger;
    }

    [HttpGet("{league}/{season?}")]
    public async Task<IActionResult> GetCalendar(RequestLeague league = RequestLeague.Main, string season = "2024/25")
    {
        season = Uri.UnescapeDataString(season);
        _logger.LogInformation("Getting calendar for {leagueName} league in season {season}.", league, season);
        var races = await _calendarService.GetCalendarAsync(league.ToString(), season);

        if (!races.Any())
        {
            _logger.LogWarning("Couldn't find calendar for {leagueName} league in season {season}.", league, season);
            return NotFound($"Couldn't find calendar for {league} league in season {season}.");
        }

        var response = new CalendarResponse
        {
            League = league.ToString(),
            Season = season,
            Races = races.Select(r => new RaceDto
            {
                Round = r.Round,
                Country = r.Circuit.Country,
                Location = r.Circuit.Location,
                Date = r.Date
            }).ToList()
        };

        return Ok(response);
    }
}

public class RaceDto
{
    [Description("The round number of the race in the season.")]
    public int Round { get; set; }

    [Description("Country of the circuit.")]
    public string Country { get; set; } = null!;

    [Description("Location of the circuit.")]
    public string Location { get; set; } = null!;

    [Description("Date of the race.")]
    public DateTime Date { get; set; }
}

public class CalendarResponse
{
    [Description("Name of the league.")]
    public string League { get; set; } = null!;

    [Description("Name of the season.")]
    public string Season { get; set; } = null!;

    [Description("List of races in the calendar.")]
    public List<RaceDto> Races { get; set; } = [];
}
