using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GRL.Persistence.Models;

internal class Circuit : IEntityTypeConfiguration<Circuit>
{
    [Key]
    [Description("Primary key for the Circuit entity.")]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    [Description("Country of the circuit.")]
    public string Country { get; set; } = null!;

    [Required]
    [MaxLength(100)]
    [Description("Location of the circuit.")]
    public string Location { get; set; } = null!;

    [Description("Collection of races held at this circuit.")]
    public virtual ICollection<Race> Races { get; set; } = new List<Race>();

    public void Configure(EntityTypeBuilder<Circuit> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .ValueGeneratedOnAdd();

        builder.Property(c => c.Country)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(c => c.Location)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasMany(c => c.Races)
            .WithOne(r => r.Circuit)
            .HasForeignKey(r => r.CircuitId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}