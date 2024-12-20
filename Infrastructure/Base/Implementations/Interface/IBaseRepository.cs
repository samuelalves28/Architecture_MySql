namespace Infrastructure.Base.Implementations.Interface;

public interface IBaseRepository<TModel>
{
    Task<List<TModel>> GetAsync(CancellationToken cancellationToken);
    Task<TModel> GetAsync(Guid id, CancellationToken cancellationToken);
    Task CreateAsync(TModel model, CancellationToken cancellationToken);
    Task UpdateAsync(TModel model, CancellationToken cancellationToken);
    Task DeleteAsync(TModel model, CancellationToken cancellationToken);
}

