using Microsoft.EntityFrameworkCore;

using MoreLife.Application.Repositories;
using MoreLife.core.Entities;
using MoreLife.Infrastructure.Persistence;

namespace MoreLife.Infrastructure.Repositories;

public class DashboardRepository : BaseRepository<Dashboard>, IDashboardRepository
{
    private readonly MoreLifeDbContext _context;

    public DashboardRepository(MoreLifeDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Dashboard> GetDashboard(CancellationToken cancellationToken)
    {
        var topFiveDonators = await _context.Donations
            .GroupBy(x => x.DonatorId)
            .Select(x => new
            {
                DonatorId = x.Key,
                TotalDonation = x.Sum(d => d.Quantity)
            })
            .OrderByDescending(x => x.TotalDonation)
            .Take(5)
            .ToListAsync(cancellationToken);

        var lastFiveDonations = await _context.Donations
            .Include(d => d.Donator) 
            .OrderByDescending(x => x.Date)
            .Take(5)
            .ToListAsync(cancellationToken);

        var totalDonations = await _context.Donations.Select(x => x.DonatorId).CountAsync(cancellationToken);
        var totalDonators = await _context.Donations.Select(x => x.DonatorId).Distinct().CountAsync(cancellationToken);
        var donationsThisMonth = await _context.Donations
            .Where(x => x.Date.Month == DateTime.Now.Month && x.Date.Year == DateTime.Now.Year)
            .Select(x => x.DonatorId).CountAsync(cancellationToken);

        var topFiveDonatorDetails = await _context.Donators
            .Where(d => topFiveDonators.Select(t => t.DonatorId).Contains(d.Id))
            .ToListAsync(cancellationToken);

        return new Dashboard(
            totalDonations,
            totalDonators,
            donationsThisMonth
            //topFiveDonatorDetails,
            //lastFiveDonations.Select(d => d.Donator).ToList()
        );
    }

}
