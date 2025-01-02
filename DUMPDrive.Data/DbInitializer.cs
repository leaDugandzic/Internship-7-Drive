using DUMPDrive.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DUMPDrive.Data;

public static class DbInitializer
{
    public static void Initialize(AppDbContext context)
    {
        if (context.Database.EnsureCreated())
        {
            var user = new User
            {
                Email = "admin@example.com",
                PasswordHash = "111" 
            };

            context.Users.Add(user);
            context.SaveChanges();
        }
    }
}
