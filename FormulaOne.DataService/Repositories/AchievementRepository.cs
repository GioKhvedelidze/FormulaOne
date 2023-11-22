using FormulaOne.DataService.Data;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FormulaOne.DataService.Repositories;

public class AchievementRepository :GenericRepository<Achievement>, IAchievementRepository
{
    public AchievementRepository(AppDbContext dbContext, ILogger logger) : base(dbContext, logger)
    { }

    public async Task<Achievement?> GetDriverAchievementAsync(Guid driverId)
    {
        try
        { 
            var result = await _dbSet.FirstOrDefaultAsync(x => x.DriverId == driverId);

            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Repo} GetDriverAchievementAsync function Error", typeof(AchievementRepository));
            throw;
        }
    }
    
    public override async Task<IEnumerable<Achievement>> All()
    {
        try
        {
            return await _dbSet.Where(x => x.Status == 1)
                .AsNoTracking()
                .AsSplitQuery()
                .OrderBy(x => x.AddDate)
                .ToListAsync();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Repo} All() function Error", typeof(AchievementRepository));
            throw;
        }
    }

    public override async Task<bool> Delete(Guid id)
    {
        try
        {
            //get my entity
            var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);

            if (result == null)
                return false;

            result.Status = 0;
            result.UpdateDate = DateTime.UtcNow;

            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Repo} Delete() function Error", typeof(AchievementRepository));
            throw;
        }
    }

    public override async Task<bool> Update(Achievement achievement)
    {
        try
        {
            var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == achievement.Id);
            
            if (result == null)
                return false;
            
            result.UpdateDate = DateTime.UtcNow;
            result.FastestLap = achievement.FastestLap;
            result.PolePosition = achievement.PolePosition;
            result.RaceWins = achievement.RaceWins;
            result.WorldChampionships = achievement.WorldChampionships;

            return true;

        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Repo} Update() function Error", typeof(AchievementRepository));
            throw;
        }
    }
}