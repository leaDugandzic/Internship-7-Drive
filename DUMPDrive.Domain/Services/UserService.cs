using DUMPDrive.Domain.Entities;

namespace DUMPDrive.Domain.Services;

public class UserService
{
    private readonly UserRepository _userRepository;

    public UserService(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public bool Register(string email, string passwordHash)
    {
        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(passwordHash))
            return false;

        return _userRepository.AddUser(new User { Email = email, PasswordHash = passwordHash });
    }

    public User? Authenticate(string email, string passwordHash)
    {
        return _userRepository.GetUser(email, passwordHash);
    }
}
