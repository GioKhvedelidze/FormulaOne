using AutoMapper;
using FormulaOne.Api.Commands;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.Dto.Requests;
using MediatR;

namespace FormulaOne.Api.Handlers;

public class AddAchievementHandler : IRequestHandler<AddAchievementRequest, Achievement>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AddAchievementHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    

    public async Task<Achievement> Handle(AddAchievementRequest request, CancellationToken cancellationToken)
    {
        var achievementEntity = _mapper.Map<Achievement>(request.AchievementRequest);

        await _unitOfWork.Achievements.Add(achievementEntity);

        await _unitOfWork.CompleteAsync();

        return achievementEntity;
    }
}