﻿using MoreLife.core.Entities;

namespace MoreLife.Application.DTOs;

public class DashboardDto
{
    public int TotalDonations { get; set; }
    public int TotalDonators {get; set; }
    public int DonationsThisMonht { get; set; }
    //public IList<Donator> TopFiveDonators { get; set; }
    //public IList<Donator> LastFiveDonations { get; set; }


}