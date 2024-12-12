using MoreLife.core.Entities;
using MoreLife.core.Enums;

namespace MoreLife.Application.Repositories;

public interface IBloodStockRepository : IBaseRepository<BloodStock>
{
    Task<BloodStock> GetByBloodType(BloodType bloodType, string rhFactor, CancellationToken cancellationToken);
}
