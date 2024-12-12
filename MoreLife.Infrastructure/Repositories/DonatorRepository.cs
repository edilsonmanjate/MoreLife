using MoreLife.Application.Repositories;
using MoreLife.core.Entities;
using MoreLife.Infrastructure.Persistence;

namespace MoreLife.Infrastructure.Repositories;

public class DonatorRepository : BaseRepository<Donator>, IDonatorRepository
{
    public DonatorRepository(MoreLifeDbContext context) : base(context)
    {
    }
}
