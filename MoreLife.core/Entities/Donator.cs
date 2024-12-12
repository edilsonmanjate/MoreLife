using MoreLife.core.Enums;
using MoreLife.core.ValueObjects;

namespace MoreLife.core.Entities;

public class Donator : BaseEntity
{
    public Donator(string name, string email, DateOnly birthDate, Genre genre, decimal weight, decimal height, BloodType bloodType, BloodRhFactor bloodRhFactor, Address address, List<Donation> donations)
    {
        Name = name;
        Email = email;
        BirthDate = birthDate;
        Genre = genre;
        Weight = weight;
        Height = height;
        BloodType = bloodType;
        BloodRhFactor = bloodRhFactor;
        Address = address;
        Donations = new List<Donation>();
    }
    private Donator()
    {
        Donations = new List<Donation>();
    }

    public string Name { get; private set; }

    public string Email { get; private set; } 
    public DateOnly BirthDate { get; private set; }
    public Genre Genre { get; private set; }
    public decimal Weight { get; private set; }
    public decimal Height { get; private set; }
    public BloodType BloodType { get; private set; }
    public BloodRhFactor BloodRhFactor { get; private set; }
    public Address Address { get; private set; }
    public List<Donation> Donations { get; private set; }

    public void UpdatePersonalInfo(string name, string email, DateOnly birthDate, Genre genre, decimal weight, decimal height, BloodType bloodType, BloodRhFactor bloodRhFactor, Address address)
    {
        Name = name;
        Email = email;
        BirthDate = birthDate;
        Genre = genre;
        Weight = weight;
        Height = height;
        BloodType = bloodType;
        BloodRhFactor = bloodRhFactor;
        Address = address;
    }


    //public void AddDonation(Donation donation)
    //{
    //    if (CanDonate(donation.Date) && IsEligibleToRegister() && !IsMinor())
    //    {
    //        Donations.Add(donation);
    //    }
    //    else
    //    {
    //        throw new InvalidOperationException(
    //        "Cannot donate at this time.");
    //    }
    //}

    public bool CanDonate(DateTime donationDate)
    {
        var lastDonation = Donations.OrderByDescending(d => d.Date).FirstOrDefault();
        if (lastDonation == null) return true;

        var daysSinceLastDonation = (donationDate - lastDonation.Date).TotalDays;
        return Genre == Genre.Male ? daysSinceLastDonation >= 60 : daysSinceLastDonation >= 90;
    }

    public bool IsEligibleToRegister()
    {
        return Weight >= 50; 
    }

    public bool IsMinor()
    {
        var today = DateOnly.FromDateTime(DateTime.Now);
        var age = today.Year - BirthDate.Year;
        if (BirthDate > today.AddYears(-age)) age--;
        return age < 18;
    }
}
