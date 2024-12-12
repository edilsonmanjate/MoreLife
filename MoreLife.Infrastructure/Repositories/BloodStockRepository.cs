using MoreLife.Application.Repositories;
using MoreLife.core.Entities;
using MoreLife.Infrastructure.Persistence;

namespace MoreLife.Infrastructure.Repositories;

public class BloodStockRepository : BaseRepository<BloodStock>, IBloodStockRepository
{
    public BloodStockRepository(MoreLifeDbContext context) : base(context)
    {
    }
}
