using MoreLife.core.Entities;

namespace MoreLife.Application.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User> ValidateUserAsync(string email, string password);
}
