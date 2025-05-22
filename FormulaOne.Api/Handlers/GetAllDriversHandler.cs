using AutoMapper;
using FormulaOne.Api.Queries;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.Dto.Requests;
using MediatR;

namespace FormulaOne.Api.Handlers;

public class GetAllDriversHandler : IRequestHandler<GetAllDriverQuery, IEnumerable<GetDriverResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllDriversHandler(IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<GetDriverResponse>> Handle(GetAllDriverQuery request, CancellationToken cancellationToken)
    {
        var driver = await _unitOfWork.Drivers.All();
        return _mapper.Map<IEnumerable<GetDriverResponse>>(driver);
    }
}