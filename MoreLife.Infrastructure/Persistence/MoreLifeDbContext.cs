using Microsoft.EntityFrameworkCore;

using MoreLife.core.Entities;

namespace MoreLife.Infrastructure.Persistence;

public class MoreLifeDbContext : DbContext
{
    public MoreLifeDbContext(DbContextOptions<MoreLifeDbContext> options) : base(options)
    {
    }

    public DbSet<Donator> Donators { get; set; }
    public DbSet<Donation> Donations { get; set; }
    public DbSet<BloodStock> BloodStocks { get; set; }

}
