using AutoMapper;
using FormulaOne.Api.Queries;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.Dto.Requests;
using MediatR;

namespace FormulaOne.Api.Handlers;

public class GetDriverAchievementsHandler : IRequestHandler<GetDriverAchievementsQuery, CreateDriverAchievementResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetDriverAchievementsHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CreateDriverAchievementResponse> Handle(GetDriverAchievementsQuery request, CancellationToken cancellationToken)
    {
        var driverAchievement = await _unitOfWork.Achievements.GetDriverAchievementAsync(request.DriverId);
        
        if (driverAchievement == null)
            return null;
        
        return _mapper.Map<CreateDriverAchievementResponse>(driverAchievement);
    }
}