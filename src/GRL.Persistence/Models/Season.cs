using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GRL.Persistence.Models;

internal class Season : IEntityTypeConfiguration<Season>
{
    [Key]
    [Description("Primary key for the Season entity.")]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    [Description("Name of the season, e.g., '2024/25'.")]
    public string Name { get; set; } = null!;

    [ForeignKey(nameof(League))]
    [Description("Foreign key to the League entity.")]
    public int LeagueId { get; set; }

    [Description("The league this season belongs to.")]
    public virtual League League { get; set; } = null!;

    // Navigation property to Races
    [Description("Collection of races in this season.")]
    public virtual ICollection<Race> Races { get; set; } = new List<Race>();

    public void Configure(EntityTypeBuilder<Season> builder)
    {
        builder.HasKey(s => s.Id);
        
        builder.Property(d => d.Id)
            .ValueGeneratedOnAdd();

        builder.Property(s => s.Id)
            .ValueGeneratedOnAdd();

        builder.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasOne(s => s.League)
            .WithMany(l => l.Seasons)
            .HasForeignKey(s => s.LeagueId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(s => s.Races)
            .WithOne(r => r.Season)
            .HasForeignKey(r => r.SeasonId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}