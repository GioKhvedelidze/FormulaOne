using FormulaOne.Entities.Dto.Requests;
using MediatR;

namespace FormulaOne.Api.Queries;

public class GetAllDriverQuery : IRequest<IEnumerable<GetDriverResponse>>
{
    
}