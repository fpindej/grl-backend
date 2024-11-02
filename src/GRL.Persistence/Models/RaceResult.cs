using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GRL.Persistence.Models;

internal class RaceResult : IEntityTypeConfiguration<RaceResult>
{
    [Key]
    [Description("Primary key for the RaceResult entity.")]
    public int Id { get; set; }

    [ForeignKey(nameof(Race))]
    [Description("Foreign key to the Race entity.")]
    public int RaceId { get; set; }

    [Description("The race associated with this result.")]
    public virtual Race Race { get; set; } = null!;

    [ForeignKey(nameof(Driver))]
    [Description("Foreign key to the Driver entity.")]
    public int DriverId { get; set; }

    [Description("The driver who achieved this result.")]
    public virtual Driver Driver { get; set; } = null!;

    [Description("The team the driver represented in this race.")]
    public int TeamId { get; set; }

    [Description("The team the driver represented in this race.")]
    public virtual Team Team { get; set; } = null!;


    [Required]
    [Description("The finishing position of the driver in the race.")]
    public int Position { get; set; }

    [Required]
    [Description("Points awarded to the driver for this race.")]
    public int PointsAwarded { get; set; }

    [Required]
    [Description("Total race time of the driver, including penalties.")]
    public TimeSpan TotalTime { get; set; }

    [Description("Collection of penalties applied to this race result.")]
    public virtual ICollection<Penalty> Penalties { get; set; } = new List<Penalty>();

    public void Configure(EntityTypeBuilder<RaceResult> builder)
    {
        builder.HasKey(rr => rr.Id);
        
        builder.Property(d => d.Id)
            .ValueGeneratedOnAdd();

        builder.Property(rr => rr.Position)
            .IsRequired();

        builder.Property(rr => rr.PointsAwarded)
            .IsRequired();

        builder.Property(rr => rr.TotalTime)
            .IsRequired();

        builder.HasOne(rr => rr.Race)
            .WithMany(r => r.RaceResults)
            .HasForeignKey(rr => rr.RaceId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(rr => rr.Driver)
            .WithMany(d => d.RaceResults)
            .HasForeignKey(rr => rr.DriverId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(rr => rr.Team)
            .WithMany()
            .HasForeignKey(rr => rr.TeamId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(rr => rr.Penalties)
            .WithOne(p => p.RaceResult)
            .HasForeignKey(p => p.RaceResultId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}