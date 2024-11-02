using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GRL.Persistence.Models;

internal class Race : IEntityTypeConfiguration<Race>
{
    [Key]
    [Description("Primary key for the Race entity.")]
    public int Id { get; set; }

    [Required]
    [Description("The round number of the race in the season.")]
    public int Round { get; set; }

    [Required]
    [Description("Date of the race.")]
    public DateTime Date { get; set; }

    // Foreign Keys

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

    // Navigation property to RaceResults
    [Description("Collection of race results for this race.")]
    public virtual ICollection<RaceResult> RaceResults { get; set; } = new List<RaceResult>();

    public void Configure(EntityTypeBuilder<Race> builder)
    {
        builder.HasKey(r => r.Id);
        
        builder.Property(d => d.Id)
            .ValueGeneratedOnAdd();

        builder.Property(r => r.Round)
            .IsRequired();

        builder.Property(r => r.Date)
            .IsRequired();

        builder.HasOne(r => r.Season)
            .WithMany(s => s.Races)
            .HasForeignKey(r => r.SeasonId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(r => r.Circuit)
            .WithMany(c => c.Races)
            .HasForeignKey(r => r.CircuitId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(r => r.RaceResults)
            .WithOne(rr => rr.Race)
            .HasForeignKey(rr => rr.RaceId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}