using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GRL.Persistence.Models;

public class League : IEntityTypeConfiguration<League>
{
    [Key]
    [Description("Primary key for the League entity.")]
    public int LeagueId { get; set; }

    [Required]
    [MaxLength(length: 50)]
    [Description("Name of the league.")]
    public string Name { get; set; } = null!;

    [Description("Collection of races associated with the league.")]
    public virtual ICollection<Race> Races { get; set; } = new List<Race>();

    public void Configure(EntityTypeBuilder<League> builder)
    {
        builder.HasKey(l => l.LeagueId);

        builder.Property(l => l.Name)
            .IsRequired()
            .HasMaxLength(maxLength: 50);

        builder.HasMany(l => l.Races)
            .WithOne(r => r.League)
            .HasForeignKey(r => r.LeagueId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}