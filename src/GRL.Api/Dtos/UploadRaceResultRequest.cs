using System.ComponentModel.DataAnnotations;

namespace GRL.Api.Dtos;

public class UploadRaceResultRequest
{
    [Required] 
    public IFormFile File { get; set; } = null!;
    
    [Required]
    public RequestLeague League { get; set; }

    [Required]
    public string Season { get; set; } = null!;
}