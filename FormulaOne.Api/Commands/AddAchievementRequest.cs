using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.Dto.Requests;
using MediatR;

namespace FormulaOne.Api.Commands;

public class AddAchievementRequest : IRequest<Achievement>
{
    public CreateDriverAchievementRequest AchievementRequest { get; }

    public AddAchievementRequest(CreateDriverAchievementRequest achievementRequest)
    {
        AchievementRequest = achievementRequest;
    }
}