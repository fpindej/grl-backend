using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GRL.Persistence.Models;

public class Season : IEntityTypeConfiguration<Season>
{
    [Key]
    [Description("Primary key for the Season entity.")]
    public int SeasonId { get; set; }

    [Required]
    [MaxLength(length: 20)]
    [Description("Name of the season, e.g., '2024/25'.")]
    public string Name { get; set; } = null!;

    [Description("Collection of races in this season.")]
    public virtual ICollection<Race> Races { get; set; } = new List<Race>();

    public void Configure(EntityTypeBuilder<Season> builder)
    {
        builder.HasKey(s => s.SeasonId);

        builder.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(maxLength: 20);

        builder.HasMany(s => s.Races)
            .WithOne(r => r.Season)
            .HasForeignKey(r => r.SeasonId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}