using Microsoft.EntityFrameworkCore;

using MoreLife.Application.Repositories;
using MoreLife.core.Entities;
using MoreLife.Infrastructure.Persistence;

namespace MoreLife.Infrastructure.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    protected readonly MoreLifeDbContext _context;

    public BaseRepository(MoreLifeDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Create(T entity)
    {
        await _context.AddAsync(entity);
        return true;
    }

    public async Task<bool> Update(T entity)
    {
        _context.Update(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Delete(T entity)
    {
        _context.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<T?> Get(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public Task<List<T>> GetAll(CancellationToken cancellationToken)
    {
        return _context.Set<T>().ToListAsync(cancellationToken);
    }
}