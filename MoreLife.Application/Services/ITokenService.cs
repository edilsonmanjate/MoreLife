using MoreLife.core.Entities;

namespace MoreLife.Application.Services;

public interface ITokenService
{
    string GenerateToken(User user);
}