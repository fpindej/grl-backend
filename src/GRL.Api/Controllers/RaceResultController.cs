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
        if (formModel?.File.Length is null or 0)
        {
            return BadRequest("No file uploaded.");
        }

        var file = formModel.File;

        var isCsvFile = file.ContentType is "text/csv" or "application/vnd.ms-excel";
        if (!isCsvFile)
        {
            return BadRequest("Invalid file type. Only CSV files are allowed.");
        }

        return Ok(file);
    }
}