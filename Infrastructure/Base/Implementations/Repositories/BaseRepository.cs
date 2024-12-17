using Infrastructure.Base.Implementations.Interface;
using Infrastructure.Base.Model;
using Infrastructure.DataBase;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Base.Implementations.Repositories;

public class BaseRepository<TModel>(DataBaseContext context) : IBaseRepository<TModel> where TModel : BaseModel
{
    public async Task<IEnumerable<TModel>> GetAllAsync()
        => await context.GetDbSet<TModel>().ToListAsync();

    public async Task<TModel?> GetByIdAsync(object id)
        => await context.GetDbSet<TModel>().FindAsync(id);

    public async Task AddAsync(TModel model)
    {
        await context.GetDbSet<TModel>().AddAsync(model);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TModel model)
    {
        context.GetDbSet<TModel>().Update(model);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(TModel model)
    {
        context.GetDbSet<TModel>().Remove(model);
        await context.SaveChangesAsync();
    }
}

