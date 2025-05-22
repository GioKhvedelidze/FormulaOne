using FormulaOne.Entities.Dto.Requests;
using MediatR;

namespace FormulaOne.Api.Queries;

public class GetDriverQuery : IRequest<GetDriverResponse>
{
    public Guid DriverId { get; }

    public GetDriverQuery(Guid driverId)
    {
        DriverId = driverId;
    }
}