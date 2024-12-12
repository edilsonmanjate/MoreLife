using MoreLife.Application.DTOs;

namespace MoreLife.Application.Services;

public interface IPostalCodeService
{
    public Task<PostalCodeDto?> CheckPostalCodeAsync(string postalCode);
}