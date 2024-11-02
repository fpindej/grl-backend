using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GRL.Persistence.Models;

internal class Penalty : IEntityTypeConfiguration<Penalty>
{
    [Key]
    [Description("Primary key for the Penalty entity.")]
    public int Id { get; set; }

    [Required]
    [Description("Type of the penalty.")]
    public PenaltyType Type { get; set; }

    [Required]
    [MaxLength(200)]
    [Description("Reason for the penalty.")]
    public string Reason { get; set; } = null!;

    [Description("Time penalty applied to the race result, if any.")]
    public TimeSpan? TimePenalty { get; set; }

    [Description("Points deducted from the race result, if any.")]
    public int? PointsDeduction { get; set; }

    [Required]
    [Description("Date and time when the penalty was applied.")]
    public DateTime AppliedOn { get; set; }

    // Foreign Key

    [ForeignKey(nameof(RaceResult))]
    [Description("Foreign key to the RaceResult entity.")]
    public int RaceResultId { get; set; }

    [Description("The race result affected by this penalty.")]
    public virtual RaceResult RaceResult { get; set; } = null!;

    public void Configure(EntityTypeBuilder<Penalty> builder)
    {
        builder.HasKey(p => p.Id);
            
        builder.Property(d => d.Id)
            .ValueGeneratedOnAdd();

        builder.Property(p => p.Type)
            .IsRequired();

        builder.Property(p => p.Reason)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(p => p.AppliedOn)
            .IsRequired();

        builder.HasOne(p => p.RaceResult)
            .WithMany(rr => rr.Penalties)
            .HasForeignKey(p => p.RaceResultId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public enum PenaltyType
{
    [Description("Time penalty applied to the driver's total race time.")]
    TimePenalty,

    [Description("Points deducted from the driver's points awarded.")]
    PointsDeduction
}