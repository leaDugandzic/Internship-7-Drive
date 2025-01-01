using DUMPDrive.Domain.Entities;

namespace DUMPDrive.Data;

public static class DbInitializer
{
    public static void Seed(AppDbContext context)
    {
        if (!context.Users.Any())
        {
            context.Users.Add(new User
            {
                Email = "admin@dumpdrive.com",
                PasswordHash = "admin123"
            });

            context.SaveChanges();
        }
    }
}
