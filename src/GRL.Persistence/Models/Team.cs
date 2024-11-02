using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GRL.Persistence.Models;

internal class Team : IEntityTypeConfiguration<Team>
{
    [Key]
    [Description("Primary key for the Team entity.")]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    [Description("Name of the team.")]
    public string Name { get; set; } = null!;

    [ForeignKey(nameof(League))]
    [Description("Foreign key to the League entity.")]
    public int LeagueId { get; set; }

    [Description("The league this team belongs to.")]
    public virtual League League { get; set; } = null!;
    
    [Description("Collection of race results associated with the team.")]
    public virtual ICollection<RaceResult> RaceResults { get; set; } = new List<RaceResult>();
    
    [Description("Collection of driver assignments to the team.")]
    public virtual ICollection<DriverTeamAssignment> DriverTeamAssignments { get; set; } = new List<DriverTeamAssignment>();


    public void Configure(EntityTypeBuilder<Team> builder)
    {
        builder.HasKey(t => t.Id);
        
        builder.Property(d => d.Id)
            .ValueGeneratedOnAdd();

        builder.Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasOne(t => t.League)
            .WithMany(l => l.Teams)
            .HasForeignKey(t => t.LeagueId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(t => t.RaceResults)
            .WithOne(rr => rr.Team)
            .HasForeignKey(rr => rr.TeamId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasMany(t => t.DriverTeamAssignments)
            .WithOne(a => a.Team)
            .HasForeignKey(a => a.TeamId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}