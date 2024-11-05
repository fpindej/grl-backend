using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GRL.Persistence.Models;

internal class Driver : IEntityTypeConfiguration<Driver>
{
    [Key]
    [Description("Primary key for the Driver entity.")]
    public int Id { get; set; }

    [Required]
    [MaxLength(length: 30)]
    [Description("First name of the driver.")]
    public string FirstName { get; set; } = null!;

    [Required]
    [MaxLength(length: 30)]
    [Description("Last name of the driver.")]
    public string LastName { get; set; } = null!;

    [Required]
    [Description("Accumulated penalty points.")]
    public int PenaltyPoints { get; set; }

    [Description("Collection of race results associated with the driver.")]
    public virtual ICollection<RaceResult> RaceResults { get; set; } = new List<RaceResult>();

    [Description("Collection of team assignments for the driver.")]
    public virtual ICollection<DriverTeamAssignment> DriverTeamAssignments { get; set; } =
        new List<DriverTeamAssignment>();

    public void Configure(EntityTypeBuilder<Driver> builder)
    {
        builder.HasKey(d => d.Id);

        builder.Property(d => d.Id)
            .ValueGeneratedOnAdd();

        builder.Property(d => d.FirstName)
            .IsRequired()
            .HasMaxLength(maxLength: 30);

        builder.Property(d => d.LastName)
            .IsRequired()
            .HasMaxLength(maxLength: 30);

        builder.Property(d => d.PenaltyPoints)
            .IsRequired();

        builder.HasMany(d => d.RaceResults)
            .WithOne(rr => rr.Driver)
            .HasForeignKey(rr => rr.DriverId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(d => d.DriverTeamAssignments)
            .WithOne(a => a.Driver)
            .HasForeignKey(a => a.DriverId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}