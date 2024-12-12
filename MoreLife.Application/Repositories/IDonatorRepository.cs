using MoreLife.core.Entities;

namespace MoreLife.Application.Repositories;

public interface IDonatorRepository : IBaseRepository<Donator>
{
    public Task<bool> IsEmailUnique(string email);
}
