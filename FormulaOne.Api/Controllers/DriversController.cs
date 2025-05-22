using AutoMapper;
using FormulaOne.Api.Commands;
using FormulaOne.Api.Queries;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.Dto.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.Api.Controllers;

public class DriversController : BaseController
{
    private readonly IMediator _mediator;
    
    public DriversController(IUnitOfWork unitOfWork, IMapper mapper, IMediator mediator) 
        : base(unitOfWork, mediator, mapper)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("{driverId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetDriverResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetDriver(Guid driverId)
    {
        var query = new GetDriverQuery(driverId);
        
        var result = await _mediator.Send(query);

        return Ok(result);
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetDriverResponse>))]
    public async Task<IActionResult> GetAllDrivers()
    {
        var query = new GetAllDriverQuery();
        
        var result = await _mediator.Send(query);
        
        return Ok(result);
    }

    [HttpPost]
    [Route("")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateDriverRequest))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> AddDriver([FromBody] CreateDriverRequest driver)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var command = new CreateDriverInfoRequest(driver);
        
        var result = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetDriver), new { driverId = result.DriverId }, result);

    }
    
    [HttpPut("")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> UpdateDriver([FromBody] UpdateDriverRequest driver)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        
        var command = new UpdateDriverInfoRequest(driver);
        
        var result = await _mediator.Send(command);
        
        return result ? NoContent() : BadRequest();
    }
    
    [HttpDelete]
    [Route("{driverId:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteDriver(Guid driverId)
    {
        var command = new DeleteDriverInfoRequest(driverId);
        
        var result = await _mediator.Send(command);

        return result ? NoContent() : BadRequest();
        
    }
    
}