using FormulaOne.Entities.Dto.Requests;
using MediatR;

namespace FormulaOne.Api.Commands;

public class UpdateDriverAchievementRequestCommand : IRequest<bool>
{
    public UpdateDriverAchievementRequest Achievement { get; }

    public UpdateDriverAchievementRequestCommand(UpdateDriverAchievementRequest achievement)
    {
        Achievement = achievement;
    }
}