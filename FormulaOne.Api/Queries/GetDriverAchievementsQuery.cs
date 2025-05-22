using FormulaOne.Entities.Dto.Requests;
using MediatR;

namespace FormulaOne.Api.Queries;

public class GetDriverAchievementsQuery : IRequest<CreateDriverAchievementResponse>
{
    public Guid DriverId { get; }

    public GetDriverAchievementsQuery(Guid achievementId)
    {
        DriverId = achievementId;
    }
}