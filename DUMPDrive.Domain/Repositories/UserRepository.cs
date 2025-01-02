using DUMPDrive.Domain.Entities;

public class UserRepository
{
    private readonly List<User> _users;

    public UserRepository(List<User> users)
    {
        _users = users;
    }

    public bool AddUser(User user)
    {
        if (_users.Any(u => u.Email == user.Email))
            return false;

        user.Id = _users.Count + 1;
        _users.Add(user);
        return true;
    }

    public User? GetUser(string email, string passwordHash)
    {
        return _users.SingleOrDefault(u => u.Email == email && u.PasswordHash == passwordHash);
    }
}
