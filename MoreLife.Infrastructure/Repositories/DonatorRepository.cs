using Microsoft.EntityFrameworkCore;

using MoreLife.Application.Repositories;
using MoreLife.core.Entities;
using MoreLife.Infrastructure.Persistence;

namespace MoreLife.Infrastructure.Repositories;

public class DonatorRepository : BaseRepository<Donator>, IDonatorRepository
{
    private readonly MoreLifeDbContext _context;
    public DonatorRepository(MoreLifeDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<bool> IsEmailUnique(string email)
    {
        return !await _context.Donators.AnyAsync(o => o.Email == email);
    }

}
