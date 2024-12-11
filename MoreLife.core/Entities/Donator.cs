using MoreLife.core.Enums;
using MoreLife.core.ValueObjects;

namespace MoreLife.core.Entities;

public class Donator : BaseEntity
{
    public Donator(string name, string email, DateOnly birthDate, Genre genre, decimal weight, decimal height, BloodType bloodType, string hrFactor, Address address, List<Donation> donations)
    {
        Name = name;
        Email = email;
        BirthDate = birthDate;
        Genre = genre;
        Weight = weight;
        Height = height;
        BloodType = bloodType;
        HRFactor = hrFactor;
        Address = address;
        Donations = donations ?? new List<Donation>();
    }

    public string Name { get; private set; }
    public string Email { get; private set; }
    public DateOnly BirthDate { get; private set; }
    public Genre Genre { get; private set; }
    public decimal Weight { get; private set; }
    public decimal Height { get; private set; }
    public BloodType BloodType { get; private set; }
    public string HRFactor { get; private set; }
    public Address Address { get; private set; }
    public List<Donation> Donations { get; private set; }

    public void UpdatePersonalInfo(string name, string email, DateOnly birthDate, Genre genre, decimal weight, decimal height, BloodType bloodType, string hrFactor, Address address)
    {
        Name = name;
        Email = email;
        BirthDate = birthDate;
        Genre = genre;
        Weight = weight;
        Height = height;
        BloodType = bloodType;
        HRFactor = hrFactor;
        Address = address;
    }

    public void AddDonation(Donation donation)
    {
        Donations.Add(donation);
    }
}
