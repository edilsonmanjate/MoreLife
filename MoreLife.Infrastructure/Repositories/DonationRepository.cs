using Microsoft.EntityFrameworkCore;

using MoreLife.Application.Repositories;
using MoreLife.core.Entities;
using MoreLife.Infrastructure.Persistence;

namespace MoreLife.Infrastructure.Repositories
{
    public class DonationRepository : BaseRepository<Donation>, IDonationRepository
    {
        public DonationRepository(MoreLifeDbContext context) : base(context)
        {
        }

        public async Task<List<Donation>> GetByDonatorId(Guid donatorId, CancellationToken cancellationToken)
        {
            return await _context.Donations.Where(x => x.DonatorId == donatorId).ToListAsync(cancellationToken);

        }
    }
}
