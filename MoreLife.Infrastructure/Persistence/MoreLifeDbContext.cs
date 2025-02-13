﻿using Microsoft.EntityFrameworkCore;

using MoreLife.core.Entities;
using MoreLife.core.Settings;
using MoreLife.Infrastructure.Persistence.Configuration;
using MoreLife.Infrastructure.Persistence.Configurations;

namespace MoreLife.Infrastructure.Persistence;

public class MoreLifeDbContext : DbContext
{
    public MoreLifeDbContext(DbContextOptions<MoreLifeDbContext> options) : base(options)
    {
    }

    public DbSet<Donator> Donators { get; set; }
    public DbSet<Donation> Donations { get; set; }
    public DbSet<BloodStock> BloodStocks { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<JwtSettings> JwtSettings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new DonatorConfiguration());
        modelBuilder.ApplyConfiguration(new DonationConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new JwtSettingsConfiguration());
    }

}
