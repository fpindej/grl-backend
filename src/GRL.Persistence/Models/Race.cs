using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GRL.Persistence.Models;

public class Race : IEntityTypeConfiguration<Race>
{
    [Key]
    [Description("Primary key for the Race entity.")]
    public int RaceId { get; set; }

    [Required]
    [Description("The round number of the race in the season.")]
    public int Round { get; set; }

    [Required]
    [Description("Date of the race.")]
    public DateTime Date { get; set; }

    // Foreign Keys

    [ForeignKey(nameof(League))]
    [Description("Foreign key to the League entity.")]
    public int LeagueId { get; set; }

    [Description("The league this race belongs to.")]
    public virtual League League { get; set; } = null!;

    [ForeignKey(nameof(Season))]
    [Description("Foreign key to the Season entity.")]
    public int SeasonId { get; set; }

    [Description("The season this race is part of.")]
    public virtual Season Season { get; set; } = null!;

    [ForeignKey(nameof(Circuit))]
    [Description("Foreign key to the Circuit entity.")]
    public int CircuitId { get; set; }

    [Description("The circuit where this race is held.")]
    public virtual Circuit Circuit { get; set; } = null!;

    public void Configure(EntityTypeBuilder<Race> builder)
    {
        builder.HasKey(r => r.RaceId);

        builder.Property(r => r.Round)
            .IsRequired();

        builder.Property(r => r.Date)
            .IsRequired();

        builder.HasOne(r => r.League)
            .WithMany(l => l.Races)
            .HasForeignKey(r => r.LeagueId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(r => r.Season)
            .WithMany(s => s.Races)
            .HasForeignKey(r => r.SeasonId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(r => r.Circuit)
            .WithMany(c => c.Races)
            .HasForeignKey(r => r.CircuitId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}