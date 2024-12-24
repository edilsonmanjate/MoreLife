namespace MoreLife.core.Entities;

public class Dashboard : BaseEntity
{
    public Dashboard(int totalDonations, int totalDonators, int donationsThisMonht)
    {
        TotalDonations = totalDonations;
        TotalDonators = totalDonators;
        DonationsThisMonht = donationsThisMonht;
        //TopFiveDonators = topFiveDonators;
        //LastFiveDonations = lastFiveDonations;
    }

    public int TotalDonations { get; set; }
    public int TotalDonators { get; set; }
    public int DonationsThisMonht { get; set; }

    //public List<Donator> TopFiveDonators { get; set; }
    //public List<Donator> LastFiveDonations { get; set; }
}
