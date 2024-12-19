namespace MoreLife.core.Entities;

public class User : BaseEntity
{
    public User(Guid id, string email, string password)
    {
        Id = id;
        Email = email;
        Password = password;
    }

    public Guid Id { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
}
