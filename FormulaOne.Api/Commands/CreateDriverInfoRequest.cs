using FormulaOne.Entities.Dto.Requests;
using MediatR;

namespace FormulaOne.Api.Commands;

public class CreateDriverInfoRequest : IRequest<GetDriverResponse>
{
    public CreateDriverRequest DriverRequest { get; }
    
    public CreateDriverInfoRequest(CreateDriverRequest driverRequest)
    {
        DriverRequest = driverRequest;
    }
}