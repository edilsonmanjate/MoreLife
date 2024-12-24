using MoreLife.core.Entities;

namespace MoreLife.Application.Repositories;

public interface IDashboardRepository : IBaseRepository<Dashboard>
{
    Task<Dashboard> GetDashboard(CancellationToken cancellationToken);
}
