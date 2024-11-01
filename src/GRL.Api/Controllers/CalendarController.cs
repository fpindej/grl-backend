using GRL.Api.Dtos;

namespace GRL.Api.Controllers;

using Microsoft.AspNetCore.Mvc;
using System;

[Route("api/[controller]")]
[ApiController]
public class CalendarController : ControllerBase
{
    [HttpGet("{leagueName}")]
    public IActionResult GetCalendar(string leagueName)
    {
        var calendarResponse = leagueName.ToLower() switch
        {
            "rookie" => GetRookieCalendar(),
            "junior" => GetJuniorCalendar(),
            "talent" => GetTalentCalendar(),
            "academy" => GetAcademyCalendar(),
            "main" => GetMainCalendar(),
            _ => null
        };

        if (calendarResponse is null)
            return NotFound($"Couldn't find calendar for {leagueName} league.");

        return Ok(calendarResponse);
    }

    private CalendarResponse GetRookieCalendar()
    {
        return new CalendarResponse
        {
            League = "Rookie",
            Season = "2024/25",
            Races =
            [
                new Race(Round: 1, RaceLocations.Bahrain, new DateTime(year: 2024, month: 10, day: 2)),
                new Race(Round: 2, RaceLocations.UnitedStatesLasVegas, new DateTime(year: 2024, month: 10, day: 9)),
                new Race(Round: 3, RaceLocations.Australia, new DateTime(year: 2024, month: 10, day: 23)),
                new Race(Round: 4, RaceLocations.Portugal, new DateTime(year: 2024, month: 10, day: 30)),
                new Race(Round: 5, RaceLocations.UnitedStatesMiami, new DateTime(year: 2024, month: 11, day: 13)),
                new Race(Round: 6, RaceLocations.Canada, new DateTime(year: 2024, month: 11, day: 20)),
                new Race(Round: 7, RaceLocations.ItalyImola, new DateTime(year: 2024, month: 12, day: 4)),
                new Race(Round: 8, RaceLocations.Spain, new DateTime(year: 2024, month: 12, day: 11)),
                new Race(Round: 9, RaceLocations.Austria, new DateTime(year: 2025, month: 1, day: 15)),
                new Race(Round: 10, RaceLocations.GreatBritain, new DateTime(year: 2025, month: 1, day: 22)),
                new Race(Round: 11, RaceLocations.Hungary, new DateTime(year: 2025, month: 2, day: 5)),
                new Race(Round: 12, RaceLocations.Belgium, new DateTime(year: 2025, month: 2, day: 12)),
                new Race(Round: 13, RaceLocations.Netherlands, new DateTime(year: 2025, month: 2, day: 26)),
                new Race(Round: 14, RaceLocations.ItalyMonza, new DateTime(year: 2025, month: 3, day: 5)),
                new Race(Round: 15, RaceLocations.Mexico, new DateTime(year: 2025, month: 3, day: 19)),
                new Race(Round: 16, RaceLocations.Singapore, new DateTime(year: 2025, month: 3, day: 26)),
                new Race(Round: 17, RaceLocations.UnitedStatesAustin, new DateTime(year: 2025, month: 4, day: 9)),
                new Race(Round: 18, RaceLocations.Brazil, new DateTime(year: 2025, month: 4, day: 16)),
                new Race(Round: 19, RaceLocations.Qatar, new DateTime(year: 2025, month: 4, day: 30)),
                new Race(Round: 20, RaceLocations.AbuDhabi, new DateTime(year: 2025, month: 5, day: 7))
            ]
        };
    }

    private CalendarResponse GetJuniorCalendar()
    {
        return new CalendarResponse
        {
            League = "Junior",
            Season = "2024/25",
            Races =
            [
                new Race(Round: 1, RaceLocations.Bahrain, new DateTime(year: 2024, month: 10, day: 8)),
                new Race(Round: 2, RaceLocations.Japan, new DateTime(year: 2024, month: 10, day: 15)),
                new Race(Round: 3, RaceLocations.Australia, new DateTime(year: 2024, month: 10, day: 29)),
                new Race(Round: 4, RaceLocations.Portugal, new DateTime(year: 2024, month: 11, day: 5)),
                new Race(Round: 5, RaceLocations.Monaco, new DateTime(year: 2024, month: 11, day: 19)),
                new Race(Round: 6, RaceLocations.Canada, new DateTime(year: 2024, month: 11, day: 26)),
                new Race(Round: 7, RaceLocations.ItalyImola, new DateTime(year: 2024, month: 12, day: 10)),
                new Race(Round: 8, RaceLocations.Spain, new DateTime(year: 2024, month: 12, day: 17)),
                new Race(Round: 9, RaceLocations.Austria, new DateTime(year: 2025, month: 1, day: 7)),
                new Race(Round: 10, RaceLocations.GreatBritain, new DateTime(year: 2025, month: 1, day: 14)),
                new Race(Round: 11, RaceLocations.Hungary, new DateTime(year: 2025, month: 1, day: 28)),
                new Race(Round: 12, RaceLocations.Belgium, new DateTime(year: 2025, month: 2, day: 4)),
                new Race(Round: 13, RaceLocations.Netherlands, new DateTime(year: 2025, month: 2, day: 18)),
                new Race(Round: 14, RaceLocations.ItalyMonza, new DateTime(year: 2025, month: 2, day: 25)),
                new Race(Round: 15, RaceLocations.Mexico, new DateTime(year: 2025, month: 3, day: 11)),
                new Race(Round: 16, RaceLocations.Singapore, new DateTime(year: 2025, month: 3, day: 18)),
                new Race(Round: 17, RaceLocations.China, new DateTime(year: 2025, month: 4, day: 1)),
                new Race(Round: 18, RaceLocations.Brazil, new DateTime(year: 2025, month: 4, day: 8)),
                new Race(Round: 19, RaceLocations.Qatar, new DateTime(year: 2025, month: 4, day: 29)),
                new Race(Round: 20, RaceLocations.AbuDhabi, new DateTime(year: 2025, month: 6, day: 5))
            ]
        };
    }
    
    private CalendarResponse GetTalentCalendar()
    {
        return new CalendarResponse
        {
            League = "Talent",
            Season = "2024/25",
            Races =
            [
                new Race(Round: 1, RaceLocations.Bahrain, new DateTime(year: 2024, month: 10, day: 5)),
                new Race(Round: 2, RaceLocations.SaudiArabia, new DateTime(year: 2024, month: 10, day: 12)),
                new Race(Round: 3, RaceLocations.Australia, new DateTime(year: 2024, month: 10, day: 26)),
                new Race(Round: 4, RaceLocations.Japan, new DateTime(year: 2024, month: 11, day: 9)),
                new Race(Round: 5, RaceLocations.UnitedStatesMiami, new DateTime(year: 2024, month: 11, day: 16)),
                new Race(Round: 6, RaceLocations.Canada, new DateTime(year: 2024, month: 11, day: 23)),
                new Race(Round: 7, RaceLocations.ItalyImola, new DateTime(year: 2024, month: 12, day: 7)),
                new Race(Round: 8, RaceLocations.Spain, new DateTime(year: 2024, month: 12, day: 14)),
                new Race(Round: 9, RaceLocations.Austria, new DateTime(year: 2025, month: 1, day: 11)),
                new Race(Round: 10, RaceLocations.GreatBritain, new DateTime(year: 2025, month: 1, day: 18)),
                new Race(Round: 11, RaceLocations.Hungary, new DateTime(year: 2025, month: 2, day: 1)),
                new Race(Round: 12, RaceLocations.Belgium, new DateTime(year: 2025, month: 2, day: 8)),
                new Race(Round: 13, RaceLocations.Netherlands, new DateTime(year: 2025, month: 2, day: 22)),
                new Race(Round: 14, RaceLocations.ItalyMonza, new DateTime(year: 2025, month: 3, day: 1)),
                new Race(Round: 15, RaceLocations.Azerbaijan, new DateTime(year: 2025, month: 3, day: 15)),
                new Race(Round: 16, RaceLocations.Singapore, new DateTime(year: 2025, month: 3, day: 22)),
                new Race(Round: 17, RaceLocations.China, new DateTime(year: 2025, month: 4, day: 5)),
                new Race(Round: 18, RaceLocations.Brazil, new DateTime(year: 2025, month: 4, day: 12)),
                new Race(Round: 19, RaceLocations.Qatar, new DateTime(year: 2025, month: 4, day: 26)),
                new Race(Round: 20, RaceLocations.AbuDhabi, new DateTime(year: 2025, month: 5, day: 10))
            ]
        };
    }

    private CalendarResponse GetAcademyCalendar()
    {
        return new CalendarResponse
        {
            League = "Academy",
            Season = "2024/25",
            Races =
            [
                new Race(Round: 1, RaceLocations.Australia, new DateTime(year: 2024, month: 9, day: 30)),
                new Race(Round: 2, RaceLocations.ItalyImola, new DateTime(year: 2024, month: 10, day: 14)),
                new Race(Round: 3, RaceLocations.UnitedStatesAustin, new DateTime(year: 2024, month: 10, day: 21)),
                new Race(Round: 4, RaceLocations.Mexico, new DateTime(year: 2024, month: 11, day: 4)),
                new Race(Round: 5, RaceLocations.Canada, new DateTime(year: 2024, month: 11, day: 11)),
                new Race(Round: 6, RaceLocations.Spain, new DateTime(year: 2024, month: 11, day: 25)),
                new Race(Round: 7, RaceLocations.Qatar, new DateTime(year: 2024, month: 12, day: 2)),
                new Race(Round: 8, RaceLocations.Austria, new DateTime(year: 2024, month: 12, day: 16)),
                new Race(Round: 9, RaceLocations.GreatBritain, new DateTime(year: 2025, month: 1, day: 6)),
                new Race(Round: 10, RaceLocations.Hungary, new DateTime(year: 2025, month: 1, day: 13)),
                new Race(Round: 11, RaceLocations.Belgium, new DateTime(year: 2025, month: 1, day: 27)),
                new Race(Round: 12, RaceLocations.Netherlands, new DateTime(year: 2025, month: 2, day: 3)),
                new Race(Round: 13, RaceLocations.ItalyMonza, new DateTime(year: 2025, month: 2, day: 17)),
                new Race(Round: 14, RaceLocations.Singapore, new DateTime(year: 2025, month: 2, day: 24)),
                new Race(Round: 15, RaceLocations.AbuDhabi, new DateTime(year: 2025, month: 3, day: 10)),
                new Race(Round: 16, RaceLocations.Monaco, new DateTime(year: 2025, month: 3, day: 17)),
                new Race(Round: 17, RaceLocations.Japan, new DateTime(year: 2025, month: 3, day: 31)),
                new Race(Round: 18, RaceLocations.Bahrain, new DateTime(year: 2025, month: 4, day: 14)),
                new Race(Round: 19, RaceLocations.SaudiArabia, new DateTime(year: 2025, month: 4, day: 28)),
                new Race(Round: 20, RaceLocations.Brazil, new DateTime(year: 2025, month: 5, day: 5))
            ]
        };
    }

    private CalendarResponse GetMainCalendar()
    {
        return new CalendarResponse
        {
            League = "Main",
            Season = "2024/25",
            Races =
            [
                new Race(Round: 1, RaceLocations.Australia, new DateTime(year: 2024, month: 9, day: 29)),
                new Race(Round: 2, RaceLocations.ItalyImola, new DateTime(year: 2024, month: 10, day: 13)),
                new Race(Round: 3, RaceLocations.Mexico, new DateTime(year: 2024, month: 10, day: 27)),
                new Race(Round: 4, RaceLocations.Canada, new DateTime(year: 2024, month: 11, day: 10)),
                new Race(Round: 5, RaceLocations.Spain, new DateTime(year: 2024, month: 11, day: 17)),
                new Race(Round: 6, RaceLocations.Qatar, new DateTime(year: 2024, month: 11, day: 24)),
                new Race(Round: 7, RaceLocations.AbuDhabi, new DateTime(year: 2024, month: 12, day: 8)),
                new Race(Round: 8, RaceLocations.Austria, new DateTime(year: 2024, month: 12, day: 15)),
                new Race(Round: 9, RaceLocations.GreatBritain, new DateTime(year: 2025, month: 1, day: 5)),
                new Race(Round: 10, RaceLocations.Hungary, new DateTime(year: 2025, month: 1, day: 12)),
                new Race(Round: 11, RaceLocations.Belgium, new DateTime(year: 2025, month: 1, day: 26)),
                new Race(Round: 12, RaceLocations.Netherlands, new DateTime(year: 2025, month: 2, day: 2)),
                new Race(Round: 13, RaceLocations.ItalyMonza, new DateTime(year: 2025, month: 2, day: 16)),
                new Race(Round: 14, RaceLocations.Singapore, new DateTime(year: 2025, month: 2, day: 23)),
                new Race(Round: 15, RaceLocations.UnitedStatesAustin, new DateTime(year: 2025, month: 3, day: 9)),
                new Race(Round: 16, RaceLocations.China, new DateTime(year: 2025, month: 3, day: 23)),
                new Race(Round: 17, RaceLocations.Japan, new DateTime(year: 2025, month: 4, day: 6)),
                new Race(Round: 18, RaceLocations.Bahrain, new DateTime(year: 2025, month: 4, day: 13)),
                new Race(Round: 19, RaceLocations.SaudiArabia, new DateTime(year: 2025, month: 4, day: 27)),
                new Race(Round: 20, RaceLocations.Brazil, new DateTime(year: 2025, month: 5, day: 11))
            ]
        };
    }
}