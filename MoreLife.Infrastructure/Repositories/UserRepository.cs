using Microsoft.EntityFrameworkCore;

using MoreLife.Application.Repositories;
using MoreLife.core.Entities;
using MoreLife.Infrastructure.Persistence;

namespace MoreLife.Infrastructure.Repositories;
public class UserRepository : BaseRepository<User>, IUserRepository
{
    private readonly MoreLifeDbContext _context;

    public UserRepository(MoreLifeDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<User?> ValidateUserAsync(string email, string password)
    {
        return await _context.Users.FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
    }
}
