using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GRL.Persistence.Models;

internal class DriverTeamAssignment : IEntityTypeConfiguration<DriverTeamAssignment>
{
    [Key]
    [Description("Primary key for the DriverTeamAssignment entity.")]
    public int Id { get; set; }

    [ForeignKey(nameof(Driver))]
    [Description("Foreign key to the Driver entity.")]
    public int DriverId { get; set; }

    [Description("The driver involved in the assignment.")]
    public virtual Driver Driver { get; set; } = null!;

    [ForeignKey(nameof(Team))]
    [Description("Foreign key to the Team entity.")]
    public int TeamId { get; set; }

    [Description("The team the driver is assigned to.")]
    public virtual Team Team { get; set; } = null!;

    [Required]
    [Description("Start date of the assignment.")]
    public DateTime StartDate { get; set; }

    [Description("End date of the assignment (null if current).")]
    public DateTime? EndDate { get; set; }

    public void Configure(EntityTypeBuilder<DriverTeamAssignment> builder)
    {
        builder.HasKey(a => a.Id);
        
        builder.Property(a => a.Id)
            .ValueGeneratedOnAdd();

        builder.Property(a => a.StartDate)
            .IsRequired();

        builder.HasOne(a => a.Driver)
            .WithMany(d => d.DriverTeamAssignments)
            .HasForeignKey(a => a.DriverId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(a => a.Team)
            .WithMany(t => t.DriverTeamAssignments)
            .HasForeignKey(a => a.TeamId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}