using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GRL.Persistence.Models;

public class Circuit : IEntityTypeConfiguration<Circuit>
{
    [Key]
    [Description("Primary key for the Circuit entity.")]
    public int CircuitId { get; set; }

    [Required]
    [MaxLength(length: 100)]
    [Description("Name of the circuit.")]
    public string Name { get; set; } = null!;

    [Required]
    [MaxLength(length: 100)]
    [Description("Location of the circuit.")]
    public string Location { get; set; } = null!;

    [Description("Collection of races held at this circuit.")]
    public virtual ICollection<Race> Races { get; set; } = new List<Race>();

    public void Configure(EntityTypeBuilder<Circuit> builder)
    {
        builder.HasKey(c => c.CircuitId);

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(maxLength: 100);

        builder.Property(c => c.Location)
            .IsRequired()
            .HasMaxLength(maxLength: 100);

        builder.HasMany(c => c.Races)
            .WithOne(r => r.Circuit)
            .HasForeignKey(r => r.CircuitId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}