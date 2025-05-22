using AutoMapper;
using FormulaOne.Api.Commands;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using MediatR;

namespace FormulaOne.Api.Handlers;

public class UpdateAchievementsHandler : IRequestHandler<UpdateDriverAchievementRequestCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateAchievementsHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<bool> Handle(UpdateDriverAchievementRequestCommand request, CancellationToken cancellationToken)
    {
        var result = _mapper.Map<Achievement>(request.Achievement);

        await _unitOfWork.Achievements.Update(result);
        await _unitOfWork.CompleteAsync();
        
        return true;
    }
}