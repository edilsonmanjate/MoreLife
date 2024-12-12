using Microsoft.EntityFrameworkCore;

using MoreLife.Application.Repositories;
using MoreLife.core.Entities;
using MoreLife.core.Enums;
using MoreLife.Infrastructure.Persistence;

namespace MoreLife.Infrastructure.Repositories;

public class BloodStockRepository : BaseRepository<BloodStock>, IBloodStockRepository
{
    public BloodStockRepository(MoreLifeDbContext context) : base(context)
    {
    }

    public async Task<BloodStock?> GetByBloodType(BloodType bloodType, string rhFactor, CancellationToken cancellationToken)
    {
        return await _context.BloodStocks.FirstOrDefaultAsync(b => b.BloodType == bloodType && b.RhFactor == rhFactor,cancellationToken);

    }
}
