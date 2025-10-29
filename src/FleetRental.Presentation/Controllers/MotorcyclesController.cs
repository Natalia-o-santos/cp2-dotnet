using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using FleetRental.Application.DTOs;
using FleetRental.Application.Services;

namespace FleetRental.Presentation.Controllers;

[ApiController]
[Route("api/motorcycles")]
public class MotorcyclesController : ControllerBase
{
    private readonly IMotorcycleService _service;
    private readonly IValidator<MotorcycleCreateRequest> _createValidator;
    private readonly IValidator<MotorcycleUpdateRequest> _updateValidator;

    public MotorcyclesController(
        IMotorcycleService service,
        IValidator<MotorcycleCreateRequest> createValidator,
        IValidator<MotorcycleUpdateRequest> updateValidator)
    {
        _service = service;
        _createValidator = createValidator;
        _updateValidator = updateValidator;
    }

    [HttpGet]
    public async Task<ActionResult<PagedResult<MotorcycleResponse>>> List([FromQuery] int page = 1, [FromQuery] int pageSize = 20)
    {
        var result = await _service.ListAsync(page, pageSize);
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<MotorcycleResponse>> Get(Guid id)
    {
        var item = await _service.GetAsync(id);
        return item is null ? NotFound() : Ok(item);
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] MotorcycleCreateRequest request)
    {
        var validation = await _createValidator.ValidateAsync(request);
        if (!validation.IsValid) return BadRequest(new ValidationProblemDetails(validation.ToDictionary()));

        var id = await _service.CreateAsync(request);
        return CreatedAtAction(nameof(Get), new { id }, new { id });
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Update(Guid id, [FromBody] MotorcycleUpdateRequest request)
    {
        var validation = await _updateValidator.ValidateAsync(request);
        if (!validation.IsValid) return BadRequest(new ValidationProblemDetails(validation.ToDictionary()));

        var ok = await _service.UpdateAsync(id, request);
        return ok ? NoContent() : NotFound();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var ok = await _service.DeleteAsync(id);
        return ok ? NoContent() : NotFound();
    }
}
