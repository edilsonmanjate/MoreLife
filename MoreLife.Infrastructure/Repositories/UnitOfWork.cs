using MoreLife.Application.Repositories;
using MoreLife.Infrastructure.Persistence;

namespace MoreLife.Infrastructure.Repositories;
public class UnitOfWork : IUnitOfWork
{
    private readonly MoreLifeDbContext _context;

    public UnitOfWork(MoreLifeDbContext context)
    {
        _context = context;
    }
    public Task Save(CancellationToken cancellationToken)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }
}