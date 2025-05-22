using FormulaOne.Entities.Dto.Requests;
using MediatR;

namespace FormulaOne.Api.Commands;

public class UpdateDriverInfoRequest : IRequest<bool>
{
    public UpdateDriverRequest Driver { get; }

    public UpdateDriverInfoRequest(UpdateDriverRequest driverRequest)
    {
        Driver = driverRequest;
    }
}