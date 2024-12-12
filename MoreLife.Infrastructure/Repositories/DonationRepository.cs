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

    }
}
