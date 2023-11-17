using Microsoft.AspNetCore.Mvc;
using RealEstate.Models.Appointment;
using RealEstate.Models.Responses;
using RealEstate.Services.Appointment;

namespace RealEstate.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AppointmentController : ControllerBase
{
    private readonly IAppointmentService _appointmentService;

    public AppointmentController(IAppointmentService appointmentService)
    {
        _appointmentService = appointmentService;

    }

    [HttpPost]
    public async Task<IActionResult> CreateAppointment([FromForm] AppointmentRegister request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var response = await _appointmentService.RegisterAppointmentAsync(request);
        if (response is not null)
            return Ok(response);

        return BadRequest(new TextResponse("Could not create new buyer"));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAppointments()
    {
        var result = await _appointmentService.GetAllAppointmentsAsync();

        if (result != null && result.Any())
            return Ok(result);

        return BadRequest(new TextResponse("There are no appointments in the database"));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAppointmentByIdAsync([FromRoute] int Id)
    {
        var response = await _appointmentService.GetAppointmentByIdAsync(Id);
        if (response is null)
            return NotFound();

        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAppointmentById([FromRoute] int id, [FromBody] UpdateAppointment updateAppointment )
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var response = await _appointmentService.UpdateAppointmentByIdAsync(id, updateAppointment);

        if (response != null)
            return Ok(response);

        return BadRequest(response);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAppointment([FromRoute] int id)
    {
        TextResponse response = await _appointmentService.DeleteAppointmentAsync(id);

        return response is not null
            ? Ok(response)
            : NotFound();
    }
}