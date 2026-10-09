using AutoMapper;
using FakeItEasy;
using FormulaOne.Api.Commands;
using FormulaOne.Api.Controllers;
using FormulaOne.Api.Queries;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.Dto.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace FormulaOne.Tests;

public class DriversControllerTests
{
    private readonly IMediator _mediator = Substitute.For<IMediator>();
    private readonly DriversController _sut;

    public DriversControllerTests()
    {
        _sut = new DriversController(
            Substitute.For<IUnitOfWork>(),
            Substitute.For<IMapper>(),
            _mediator);
    }
    
    [Fact]
    public async Task GetDrivers_Returns_The_Correct_Response()
    {
        IEnumerable<GetDriverResponse> drivers =
        [
            new() { DriverId = Guid.NewGuid(), FullName = "Lewis Hamilton", DriverNumber = 44 }
        ];
        _mediator.Send(Arg.Any<GetAllDriverQuery>(), Arg.Any<CancellationToken>()).Returns(drivers);

        // Act
        var result = await _sut.GetAllDrivers();

        // Assert
        var ok = Assert.IsType<OkObjectResult>(result);
        Assert.Same(drivers, ok.Value);
        await _mediator.Received(1).Send(Arg.Any<GetAllDriverQuery>(), Arg.Any<CancellationToken>());
    }
    
    [Fact]
    public async Task AddDriver_ReturnsCreatedAtActionPointingToGetDriver()
    {
        var created = new GetDriverResponse { DriverId = Guid.NewGuid(), FullName = "Max Verstappen" };
        _mediator.Send(Arg.Any<CreateDriverInfoRequest>(), Arg.Any<CancellationToken>()).Returns(created);

        var result = await _sut.AddDriver(new CreateDriverRequest { FirstName = "Max", LastName = "Verstappen" });

        var createdResult = Assert.IsType<CreatedAtActionResult>(result);
        Assert.Equal(nameof(DriversController.GetDriver), createdResult.ActionName);
        Assert.Equal(created.DriverId, createdResult.RouteValues!["driverId"]);
        Assert.Same(created, createdResult.Value);
    }
}
