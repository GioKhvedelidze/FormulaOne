using FormulaOne.DataService.Data;
using FormulaOne.DataService.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace FormulaOne.DataService.Repositories;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly AppDbContext _dbContext;
    
    public IDriverRepository Drivers { get; }
    public IAchievementRepository Achievements { get; }

    public UnitOfWork(AppDbContext dBcontext, ILoggerFactory loggerFactory)
    {
        _dbContext = dBcontext;

        var logger = loggerFactory.CreateLogger("logs");


        Drivers = new DriverRepository(_dbContext, logger);
        Achievements = new AchievementRepository(_dbContext, logger);
    }

    public async Task<bool> CompleteAsync()
    {
        var result = await _dbContext.SaveChangesAsync();

        return result > 0;
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }
    
    
}