namespace DUMPDrive.Domain.Abstractions;

using DUMPDrive.Domain.Entities;

public interface IUserRepository : IRepository<User>
{
    User? GetByEmail(string email);
}
