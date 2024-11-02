using GRL.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace GRL.Persistence;

internal static class DataSeeder
{
    public static ModelBuilder SeedData(this ModelBuilder modelBuilder)
    {
        var leagues = SeedLeagues(modelBuilder);
        var seasons = SeedSeasons(modelBuilder, leagues);
        var circuits = SeedCircuits(modelBuilder);
        SeedRaces(modelBuilder, seasons, circuits);

        return modelBuilder;
    }

    private static List<League> SeedLeagues(ModelBuilder modelBuilder)
    {
        var leagues = new List<League>
        {
            new() { Id = 1, Name = "Rookie" },
            new() { Id = 2, Name = "Junior" },
            new() { Id = 3, Name = "Talent" },
            new() { Id = 4, Name = "Academy" },
            new() { Id = 5, Name = "Main" }
        };

        modelBuilder.Entity<League>().HasData(leagues);

        return leagues;
    }

    private static List<Circuit> SeedCircuits(ModelBuilder modelBuilder)
    {
        var circuits = new List<Circuit>
        {
            new() { Id = 1, Location = "Sakhir", Country = "Bahrain" },
            new() { Id = 2, Location = "Las Vegas", Country = "United States" },
            new() { Id = 3, Location = "Melbourne", Country = "Australia" },
            new() { Id = 4, Location = "Algarve", Country = "Portugal" },
            new() { Id = 5, Location = "Miami", Country = "United States" },
            new() { Id = 6, Location = "Montreal", Country = "Canada" },
            new() { Id = 7, Location = "Imola", Country = "Italy" },
            new() { Id = 8, Location = "Barcelona", Country = "Spain" },
            new() { Id = 9, Location = "Spielberg", Country = "Austria" },
            new() { Id = 10, Location = "Silverstone", Country = "Great Britain" },
            new() { Id = 11, Location = "Mogyoród", Country = "Hungary" },
            new() { Id = 12, Location = "Spa-Francorchamps", Country = "Belgium" },
            new() { Id = 13, Location = "Zandvoort", Country = "Netherlands" },
            new() { Id = 14, Location = "Monza", Country = "Italy" },
            new() { Id = 15, Location = "Mexico City", Country = "Mexico" },
            new() { Id = 16, Location = "Marina Bay", Country = "Singapore" },
            new() { Id = 17, Location = "Austin", Country = "United States" },
            new() { Id = 18, Location = "São Paulo", Country = "Brazil" },
            new() { Id = 19, Location = "Lusail", Country = "Qatar" },
            new() { Id = 20, Location = "Yas Marina", Country = "Abu Dhabi" },
            new() { Id = 21, Location = "Suzuka", Country = "Japan" },
            new() { Id = 22, Location = "Monte Carlo", Country = "Monaco" },
            new() { Id = 23, Location = "Shanghai", Country = "China" },
            new() { Id = 24, Location = "Jeddah", Country = "Saudi Arabia" },
            new() { Id = 25, Location = "Baku", Country = "Azerbaijan" }
        };

        modelBuilder.Entity<Circuit>().HasData(circuits);

        return circuits;
    }

    private static List<Season> SeedSeasons(ModelBuilder modelBuilder, List<League> leagues)
    {
        var seasons = new List<Season>();

        var seasonId = 1;

        foreach (var league in leagues)
        {
            var season = new Season
            {
                Id = seasonId++,
                Name = "2024/25",
                LeagueId = league.Id
            };

            seasons.Add(season);
        }

        modelBuilder.Entity<Season>().HasData(seasons);

        return seasons;
    }

    private static void SeedRaces(ModelBuilder modelBuilder, List<Season> seasons, List<Circuit> circuits)
    {
        var races = new List<Race>();
        var raceId = 1;

        int GetCircuitIdByLocation(string location)
        {
            var circuit = circuits.FirstOrDefault(c => c.Location == location);

            if (circuit is null)
                throw new Exception($"Unknown circuit with Location: {location}");

            return circuit.Id;
        }

        var leagueRaces = new Dictionary<int, List<(int Round, string Location, DateTime Date)>>()
        {
            // League 1 Races
            {
                1, [
                    (1, "Sakhir", DateTime.SpecifyKind(new DateTime(year: 2024, month: 10, day: 2), DateTimeKind.Utc)),
                    (2, "Las Vegas", DateTime.SpecifyKind(new DateTime(year: 2024, month: 10, day: 9), DateTimeKind.Utc)),
                    (3, "Melbourne", DateTime.SpecifyKind(new DateTime(year: 2024, month: 10, day: 23), DateTimeKind.Utc)),
                    (4, "Algarve", DateTime.SpecifyKind(new DateTime(year: 2024, month: 10, day: 30), DateTimeKind.Utc)),
                    (5, "Miami", DateTime.SpecifyKind(new DateTime(year: 2024, month: 11, day: 13), DateTimeKind.Utc)),
                    (6, "Montreal", DateTime.SpecifyKind(new DateTime(year: 2024, month: 11, day: 20), DateTimeKind.Utc)),
                    (7, "Imola", DateTime.SpecifyKind(new DateTime(year: 2024, month: 12, day: 4), DateTimeKind.Utc)),
                    (8, "Barcelona", DateTime.SpecifyKind(new DateTime(year: 2024, month: 12, day: 11), DateTimeKind.Utc)),
                    (9, "Spielberg", DateTime.SpecifyKind(new DateTime(year: 2025, month: 1, day: 15), DateTimeKind.Utc)),
                    (10, "Silverstone", DateTime.SpecifyKind(new DateTime(year: 2025, month: 1, day: 22), DateTimeKind.Utc)),
                    (11, "Mogyoród", DateTime.SpecifyKind(new DateTime(year: 2025, month: 2, day: 5), DateTimeKind.Utc)),
                    (12, "Spa-Francorchamps", DateTime.SpecifyKind(new DateTime(year: 2025, month: 2, day: 12), DateTimeKind.Utc)),
                    (13, "Zandvoort", DateTime.SpecifyKind(new DateTime(year: 2025, month: 2, day: 26), DateTimeKind.Utc)),
                    (14, "Monza", DateTime.SpecifyKind(new DateTime(year: 2025, month: 3, day: 5), DateTimeKind.Utc)),
                    (15, "Mexico City", DateTime.SpecifyKind(new DateTime(year: 2025, month: 3, day: 19), DateTimeKind.Utc)),
                    (16, "Marina Bay", DateTime.SpecifyKind(new DateTime(year: 2025, month: 3, day: 26), DateTimeKind.Utc)),
                    (17, "Austin", DateTime.SpecifyKind(new DateTime(year: 2025, month: 4, day: 9), DateTimeKind.Utc)),
                    (18, "São Paulo", DateTime.SpecifyKind(new DateTime(year: 2025, month: 4, day: 16), DateTimeKind.Utc)),
                    (19, "Lusail", DateTime.SpecifyKind(new DateTime(year: 2025, month: 4, day: 30), DateTimeKind.Utc)),
                    (20, "Yas Marina", DateTime.SpecifyKind(new DateTime(year: 2025, month: 5, day: 7), DateTimeKind.Utc))
                ]
            },
            // League 2 Races
            {
                2, [
                    (1, "Sakhir", DateTime.SpecifyKind(new DateTime(year: 2024, month: 10, day: 8), DateTimeKind.Utc)),
                    (2, "Suzuka", DateTime.SpecifyKind(new DateTime(year: 2024, month: 10, day: 15), DateTimeKind.Utc)),
                    (3, "Melbourne", DateTime.SpecifyKind(new DateTime(year: 2024, month: 10, day: 29), DateTimeKind.Utc)),
                    (4, "Algarve", DateTime.SpecifyKind(new DateTime(year: 2024, month: 11, day: 5), DateTimeKind.Utc)),
                    (5, "Monte Carlo", DateTime.SpecifyKind(new DateTime(year: 2024, month: 11, day: 19), DateTimeKind.Utc)),
                    (6, "Montreal", DateTime.SpecifyKind(new DateTime(year: 2024, month: 11, day: 26), DateTimeKind.Utc)),
                    (7, "Imola", DateTime.SpecifyKind(new DateTime(year: 2024, month: 12, day: 10), DateTimeKind.Utc)),
                    (8, "Barcelona", DateTime.SpecifyKind(new DateTime(year: 2024, month: 12, day: 17), DateTimeKind.Utc)),
                    (9, "Spielberg", DateTime.SpecifyKind(new DateTime(year: 2025, month: 1, day: 7), DateTimeKind.Utc)),
                    (10, "Silverstone", DateTime.SpecifyKind(new DateTime(year: 2025, month: 1, day: 14), DateTimeKind.Utc)),
                    (11, "Mogyoród", DateTime.SpecifyKind(new DateTime(year: 2025, month: 1, day: 28), DateTimeKind.Utc)),
                    (12, "Spa-Francorchamps", DateTime.SpecifyKind(new DateTime(year: 2025, month: 2, day: 4), DateTimeKind.Utc)),
                    (13, "Zandvoort", DateTime.SpecifyKind(new DateTime(year: 2025, month: 2, day: 18), DateTimeKind.Utc)),
                    (14, "Monza", DateTime.SpecifyKind(new DateTime(year: 2025, month: 2, day: 25), DateTimeKind.Utc)),
                    (15, "Mexico City", DateTime.SpecifyKind(new DateTime(year: 2025, month: 3, day: 11), DateTimeKind.Utc)),
                    (16, "Marina Bay", DateTime.SpecifyKind(new DateTime(year: 2025, month: 3, day: 18), DateTimeKind.Utc)),
                    (17, "Shanghai", DateTime.SpecifyKind(new DateTime(year: 2025, month: 4, day: 1), DateTimeKind.Utc)),
                    (18, "São Paulo", DateTime.SpecifyKind(new DateTime(year: 2025, month: 4, day: 8), DateTimeKind.Utc)),
                    (19, "Lusail", DateTime.SpecifyKind(new DateTime(year: 2025, month: 4, day: 29), DateTimeKind.Utc)),
                    (20, "Yas Marina", DateTime.SpecifyKind(new DateTime(year: 2025, month: 6, day: 5), DateTimeKind.Utc))
                ]
            },
            // League 3 Races
            {
                3, [
                    (1, "Sakhir", DateTime.SpecifyKind(new DateTime(year: 2024, month: 10, day: 5), DateTimeKind.Utc)),
                    (2, "Jeddah", DateTime.SpecifyKind(new DateTime(year: 2024, month: 10, day: 12), DateTimeKind.Utc)),
                    (3, "Melbourne", DateTime.SpecifyKind(new DateTime(year: 2024, month: 10, day: 26), DateTimeKind.Utc)),
                    (4, "Suzuka", DateTime.SpecifyKind(new DateTime(year: 2024, month: 11, day: 9), DateTimeKind.Utc)),
                    (5, "Miami", DateTime.SpecifyKind(new DateTime(year: 2024, month: 11, day: 16), DateTimeKind.Utc)),
                    (6, "Montreal", DateTime.SpecifyKind(new DateTime(year: 2024, month: 11, day: 23), DateTimeKind.Utc)),
                    (7, "Imola", DateTime.SpecifyKind(new DateTime(year: 2024, month: 12, day: 7), DateTimeKind.Utc)),
                    (8, "Barcelona", DateTime.SpecifyKind(new DateTime(year: 2024, month: 12, day: 14), DateTimeKind.Utc)),
                    (9, "Spielberg", DateTime.SpecifyKind(new DateTime(year: 2025, month: 1, day: 11), DateTimeKind.Utc)),
                    (10, "Silverstone", DateTime.SpecifyKind(new DateTime(year: 2025, month: 1, day: 18), DateTimeKind.Utc)),
                    (11, "Mogyoród", DateTime.SpecifyKind(new DateTime(year: 2025, month: 2, day: 1), DateTimeKind.Utc)),
                    (12, "Spa-Francorchamps", DateTime.SpecifyKind(new DateTime(year: 2025, month: 2, day: 8), DateTimeKind.Utc)),
                    (13, "Zandvoort", DateTime.SpecifyKind(new DateTime(year: 2025, month: 2, day: 22), DateTimeKind.Utc)),
                    (14, "Monza", DateTime.SpecifyKind(new DateTime(year: 2025, month: 3, day: 1), DateTimeKind.Utc)),
                    (15, "Baku", DateTime.SpecifyKind(new DateTime(year: 2025, month: 3, day: 15), DateTimeKind.Utc)),
                    (16, "Marina Bay", DateTime.SpecifyKind(new DateTime(year: 2025, month: 3, day: 22), DateTimeKind.Utc)),
                    (17, "Shanghai", DateTime.SpecifyKind(new DateTime(year: 2025, month: 4, day: 5), DateTimeKind.Utc)),
                    (18, "São Paulo", DateTime.SpecifyKind(new DateTime(year: 2025, month: 4, day: 12), DateTimeKind.Utc)),
                    (19, "Lusail", DateTime.SpecifyKind(new DateTime(year: 2025, month: 4, day: 26), DateTimeKind.Utc)),
                    (20, "Yas Marina", DateTime.SpecifyKind(new DateTime(year: 2025, month: 5, day: 10), DateTimeKind.Utc))
                ]
            },
            // League 4 Races
            {
                4, [
                    (1, "Melbourne", DateTime.SpecifyKind(new DateTime(year: 2024, month: 9, day: 30), DateTimeKind.Utc)),
                    (2, "Imola", DateTime.SpecifyKind(new DateTime(year: 2024, month: 10, day: 14), DateTimeKind.Utc)),
                    (3, "Austin", DateTime.SpecifyKind(new DateTime(year: 2024, month: 10, day: 21), DateTimeKind.Utc)),
                    (4, "Mexico City", DateTime.SpecifyKind(new DateTime(year: 2024, month: 11, day: 4), DateTimeKind.Utc)),
                    (5, "Montreal", DateTime.SpecifyKind(new DateTime(year: 2024, month: 11, day: 11), DateTimeKind.Utc)),
                    (6, "Barcelona", DateTime.SpecifyKind(new DateTime(year: 2024, month: 11, day: 25), DateTimeKind.Utc)),
                    (7, "Lusail", DateTime.SpecifyKind(new DateTime(year: 2024, month: 12, day: 2), DateTimeKind.Utc)),
                    (8, "Spielberg", DateTime.SpecifyKind(new DateTime(year: 2024, month: 12, day: 16), DateTimeKind.Utc)),
                    (9, "Silverstone", DateTime.SpecifyKind(new DateTime(year: 2025, month: 1, day: 6), DateTimeKind.Utc)),
                    (10, "Mogyoród", DateTime.SpecifyKind(new DateTime(year: 2025, month: 1, day: 13), DateTimeKind.Utc)),
                    (11, "Spa-Francorchamps", DateTime.SpecifyKind(new DateTime(year: 2025, month: 1, day: 27), DateTimeKind.Utc)),
                    (12, "Zandvoort", DateTime.SpecifyKind(new DateTime(year: 2025, month: 2, day: 3), DateTimeKind.Utc)),
                    (13, "Monza", DateTime.SpecifyKind(new DateTime(year: 2025, month: 2, day: 17), DateTimeKind.Utc)),
                    (14, "Marina Bay", DateTime.SpecifyKind(new DateTime(year: 2025, month: 2, day: 24), DateTimeKind.Utc)),
                    (15, "Yas Marina", DateTime.SpecifyKind(new DateTime(year: 2025, month: 3, day: 10), DateTimeKind.Utc)),
                    (16, "Monte Carlo", DateTime.SpecifyKind(new DateTime(year: 2025, month: 3, day: 17), DateTimeKind.Utc)),
                    (17, "Suzuka", DateTime.SpecifyKind(new DateTime(year: 2025, month: 3, day: 31), DateTimeKind.Utc)),
                    (18, "Sakhir", DateTime.SpecifyKind(new DateTime(year: 2025, month: 4, day: 14), DateTimeKind.Utc)),
                    (19, "Jeddah", DateTime.SpecifyKind(new DateTime(year: 2025, month: 4, day: 28), DateTimeKind.Utc)),
                    (20, "São Paulo", DateTime.SpecifyKind(new DateTime(year: 2025, month: 5, day: 5), DateTimeKind.Utc))
                ]
            },
            // League 5 Races
            {
                5, [
                    (1, "Melbourne", DateTime.SpecifyKind(new DateTime(year: 2024, month: 9, day: 29), DateTimeKind.Utc)),
                    (2, "Imola", DateTime.SpecifyKind(new DateTime(year: 2024, month: 10, day: 13), DateTimeKind.Utc)),
                    (3, "Mexico City", DateTime.SpecifyKind(new DateTime(year: 2024, month: 10, day: 27), DateTimeKind.Utc)),
                    (4, "Montreal", DateTime.SpecifyKind(new DateTime(year: 2024, month: 11, day: 10), DateTimeKind.Utc)),
                    (5, "Barcelona", DateTime.SpecifyKind(new DateTime(year: 2024, month: 11, day: 17), DateTimeKind.Utc)),
                    (6, "Lusail", DateTime.SpecifyKind(new DateTime(year: 2024, month: 11, day: 24), DateTimeKind.Utc)),
                    (7, "Yas Marina", DateTime.SpecifyKind(new DateTime(year: 2024, month: 12, day: 8), DateTimeKind.Utc)),
                    (8, "Spielberg", DateTime.SpecifyKind(new DateTime(year: 2024, month: 12, day: 15), DateTimeKind.Utc)),
                    (9, "Silverstone", DateTime.SpecifyKind(new DateTime(year: 2025, month: 1, day: 5), DateTimeKind.Utc)),
                    (10, "Mogyoród", DateTime.SpecifyKind(new DateTime(year: 2025, month: 1, day: 12), DateTimeKind.Utc)),
                    (11, "Spa-Francorchamps", DateTime.SpecifyKind(new DateTime(year: 2025, month: 1, day: 26), DateTimeKind.Utc)),
                    (12, "Zandvoort", DateTime.SpecifyKind(new DateTime(year: 2025, month: 2, day: 2), DateTimeKind.Utc)),
                    (13, "Monza", DateTime.SpecifyKind(new DateTime(year: 2025, month: 2, day: 16), DateTimeKind.Utc)),
                    (14, "Marina Bay", DateTime.SpecifyKind(new DateTime(year: 2025, month: 2, day: 23), DateTimeKind.Utc)),
                    (15, "Austin", DateTime.SpecifyKind(new DateTime(year: 2025, month: 3, day: 9), DateTimeKind.Utc)),
                    (16, "Shanghai", DateTime.SpecifyKind(new DateTime(year: 2025, month: 3, day: 23), DateTimeKind.Utc)),
                    (17, "Suzuka", DateTime.SpecifyKind(new DateTime(year: 2025, month: 4, day: 6), DateTimeKind.Utc)),
                    (18, "Sakhir", DateTime.SpecifyKind(new DateTime(year: 2025, month: 4, day: 13), DateTimeKind.Utc)),
                    (19, "Jeddah", DateTime.SpecifyKind(new DateTime(year: 2025, month: 4, day: 27), DateTimeKind.Utc)),
                    (20, "São Paulo", DateTime.SpecifyKind(new DateTime(year: 2025, month: 5, day: 11), DateTimeKind.Utc))
                ]
            }
        };

        foreach (var season in seasons)
        {
            if (!leagueRaces.TryGetValue(season.LeagueId, out var racesForSeason))
                throw new Exception($"No race data found for LeagueId: {season.LeagueId}");

            foreach (var (round, location, date) in racesForSeason)
            {
                var race = new Race
                {
                    Id = raceId++,
                    Round = round,
                    Date = date,
                    SeasonId = season.Id,
                    CircuitId = GetCircuitIdByLocation(location)
                };

                races.Add(race);
            }
        }

        modelBuilder.Entity<Race>().HasData(races);
    }
}