using System.ComponentModel.DataAnnotations;

namespace GRL.Api.Dtos;

public class UploadRaceResultRequest
{
    [Required] 
    public IFormFile File { get; set; } = null!;
    
    public string League { get; set; }
    
    public string Season { get; set; }
}