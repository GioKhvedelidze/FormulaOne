using AutoMapper;
using FormulaOne.Api.Commands;
using FormulaOne.Api.Queries;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.Dto.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.Api.Controllers;

public class AchievementsController : BaseController
{
    public AchievementsController(IUnitOfWork unitOfWork, IMediator mediator,
        IMapper mapper) : base(unitOfWork, mediator, mapper)
    {
    }

    [HttpGet]
    [Route("{driverId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreateDriverAchievementResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetDriverAchievements(Guid driverId)
    {
        var result = await _mediator.Send(new GetDriverAchievementsQuery(driverId));
        
        if (result == null)
            return NotFound("Achievements not found for this driver");
        
        return Ok(result);
    }

    [HttpPost("")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Achievement))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> AddAchievement([FromBody] CreateDriverAchievementRequest achievement)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var command = new AddAchievementRequest(achievement);

        var result = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetDriverAchievements), new { driverId = result.DriverId}, result);
    }

    [HttpPut("")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> UpdateAchievements([FromBody] UpdateDriverAchievementRequest achievement)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var command = new UpdateDriverAchievementRequestCommand(achievement);
        
        var result = await _mediator.Send(command);
        
        return result ? NoContent() : BadRequest();
    }
    
}