using GRL.Api.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace GRL.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class RaceResultController : ControllerBase
{
    
    [HttpPost("upload")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> UploadRaceResult([FromForm] UploadRaceResultRequest? formModel)
    {
        if (formModel?.File.Length is 0)
        {
            return BadRequest("No file uploaded.");
        }

        var file = formModel!.File;

        return Ok(file);
    }
}