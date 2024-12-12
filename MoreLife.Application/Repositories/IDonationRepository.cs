using MoreLife.core.Entities;

namespace MoreLife.Application.Repositories;

public interface IDonationRepository : IBaseRepository<Donation>
{
    Task<List<Donation>> GetByDonatorId(Guid donatorId, CancellationToken cancellationToken);
}
