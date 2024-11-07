using GRL.Api.Dtos;
using GRL.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace GRL.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class DriversController : ControllerBase
{
    private readonly IDriverService _driverService;

    public DriversController(IDriverService driverService)
    {
        _driverService = driverService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetDriverResponse>>> GetAllDrivers()
    {
        var drivers = await _driverService.GetAllDriversAsync();

        var response = drivers.Select(d => new GetDriverResponse(d.Id, d.FirstName, d.LastName));
        return Ok(response);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<GetDriverResponse>> GetDriverById(int id)
    {
        var driver = await _driverService.GetDriverByIdAsync(id);

        var response = new GetDriverResponse(driver.Id, driver.FirstName, driver.LastName);
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<CreateDriverResponse>> CreateDriver([FromBody] CreateDriverRequest request)
    {
        var driver = await _driverService.AddDriverAsync(request.FirstName, request.LastName);

        var response = new CreateDriverResponse(driver.Id, driver.FirstName, driver.LastName);
        return CreatedAtAction(nameof(GetDriverById), new { id = response.Id }, response);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteDriver(int id)
    {
        await _driverService.DeleteDriverAsync(id);

        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UpdateDriverResponse>> UpdateDriver(int id, [FromBody] UpdateDriverRequest request)
    {
        var updatedDriver = await _driverService.UpdateDriverAsync(id, request.FirstName, request.LastName);

        var response = new UpdateDriverResponse(updatedDriver.Id, updatedDriver.FirstName, updatedDriver.LastName);
        return Ok(response);
    }
}