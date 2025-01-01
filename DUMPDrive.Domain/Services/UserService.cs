using DUMPDrive.Domain.Entities;

namespace DUMPDrive.Domain.Services;

public class UserService
{
    private readonly List<User> _users;

    public UserService(List<User> users)
    {
        _users = users;
    }

    public User? Authenticate(string email, string passwordHash)
    {
        return _users.SingleOrDefault(u => u.Email == email && u.PasswordHash == passwordHash);
    }

    public bool Register(string email, string passwordHash)
    {
        if (_users.Any(u => u.Email == email))
            return false;

        _users.Add(new User { Email = email, PasswordHash = passwordHash });
        return true;
    }
}
