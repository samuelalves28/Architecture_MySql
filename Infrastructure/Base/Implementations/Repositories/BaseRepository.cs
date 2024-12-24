using Infrastructure.Base.Implementations.Interface;
using Infrastructure.Base.Model;
using Infrastructure.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Base.Implementations.Repositories;

public class BaseRepository<TModel>(DataBaseContext context, ILogger<BaseRepository<TModel>> logger) : IBaseRepository<TModel> where TModel : BaseModel
{
    protected readonly DbSet<TModel> _dbSet = context.GetDbSet<TModel>();

    public async Task<List<TModel>> GetAsync(CancellationToken cancellationToken)
        => await _dbSet.ToListAsync(cancellationToken: cancellationToken);

    public async Task<TModel> GetAsync(Guid id, CancellationToken cancellationToken)
        => await _dbSet.SingleAsync(w => w.Id == id, cancellationToken);

    public async Task CreateAsync(TModel model, CancellationToken cancellationToken)
    {
        await _dbSet.AddAsync(model, cancellationToken: cancellationToken);
        await SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(TModel model, CancellationToken cancellationToken)
    {
        _dbSet.Update(model);
        await SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var model = await _dbSet.SingleAsync(w => w.Id == id, cancellationToken);
        _dbSet.Remove(model);
        await SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(TModel model, CancellationToken cancellationToken)
    {
        _dbSet.Remove(model);
        await SaveChangesAsync(cancellationToken);
    }

    protected async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        try
        {
            await context.SaveChangesAsync(cancellationToken: cancellationToken);
        }
        catch (DbUpdateException ex)
        {
            logger.LogError(ex, "Error saving changes to the database");
            throw new InvalidOperationException("Could not save changes to the database. See inner exception for details.", ex);
        }
        finally
        {
            await context.Database.CloseConnectionAsync();
        }
    }
}
