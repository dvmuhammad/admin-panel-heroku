using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Event;

namespace AdminPanel.Controllers;

[ApiController]
public class EventsController : ControllerBase
{
    private readonly IEventService _service;

    public EventsController(IEventService service)
    {
        _service = service;
    }

    [HttpPost("event")]
    public async Task<IActionResult> Post([FromForm]EventCreationRequest request)
    {
        await _service.CreateEvent(request);
        return Ok();
    }

    [HttpGet("events")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAllEvent());
    }
    [HttpPut("event/update/{id:int}")]
    public async Task<IActionResult> Update(int id, [FromForm]EventUpdateRequest request)
    {
        var result = await _service.UpdateById(id,request);
        return Ok(result);
    }
    [HttpDelete("event/delete/{id:int}")]
    public async Task<IActionResult> DeleteById(int id)
    {
        var result = await _service.DeleteById(id);
        return Ok(result);
    }
}