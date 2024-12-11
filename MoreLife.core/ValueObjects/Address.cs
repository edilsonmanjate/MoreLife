namespace MoreLife.core.ValueObjects;

public class Address
{
    public Guid Id { get; private set; }
    public string Street { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string PostalCode { get; private set; }

    public Address(Guid id, string street, string city, string state, string postalCode)
    {
        Id = id;
        Street = street;
        City = city;
        State = state;
        PostalCode = postalCode;
    }

    // Override Equals and GetHashCode for value object comparison
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        var other = (Address)obj;
        return Id == other.Id &&
               Street == other.Street &&
               City == other.City &&
               State == other.State &&
               PostalCode == other.PostalCode;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Street, City, State, PostalCode);
    }
}