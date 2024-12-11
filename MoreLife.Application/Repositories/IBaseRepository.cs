using MoreLife.core.Entities;

namespace MoreLife.Application.Repositories;

public interface IBaseRepository<T> where T : BaseEntity
{
    Task<bool> Create(T entity);
    Task<bool> Update(T entity);
    Task<bool> Delete(T entity);
    Task<T> Get(Guid id, CancellationToken cancellationToken);
    Task<List<T>> GetAll(CancellationToken cancellationToken);
}