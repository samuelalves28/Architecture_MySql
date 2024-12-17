namespace Infrastructure.Base.Implementations.Interface;

public interface IBaseRepository<TModel>
{
    Task<IEnumerable<TModel>> GetAllAsync();
    Task<TModel?> GetByIdAsync(object id);
    Task AddAsync(TModel model);
    Task UpdateAsync(TModel model);
    Task DeleteAsync(TModel model);
}

