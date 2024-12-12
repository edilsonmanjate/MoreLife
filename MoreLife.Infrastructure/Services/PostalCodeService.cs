using MoreLife.Application.DTOs;
using MoreLife.Application.Services;

using System.Text.Json;

namespace MoreLife.Infrastructure.Services;

public class PostalCodeService : IPostalCodeService
{
    private HttpClient _httpClient;

    public PostalCodeService()
    {
        _httpClient = new HttpClient();
    }

    public async Task<PostalCodeDto?> CheckPostalCodeAsync(string postalCode)
    {
        var response = await _httpClient.GetAsync($"https://viacep.com.br/ws/{postalCode}/json/");
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var postalCodeDto = JsonSerializer.Deserialize<PostalCodeDto>(content);
            return postalCodeDto;
        }
        return null;
    }
}