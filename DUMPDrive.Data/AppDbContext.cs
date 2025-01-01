using Microsoft.EntityFrameworkCore;
using DUMPDrive.Domain.Entities;

namespace DUMPDrive.Data;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<FileItem> FileItems { get; set; }
    public DbSet<Folder> Folders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=dumpdrive.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

        modelBuilder.Entity<FileItem>()
            .HasOne(f => f.Owner)
            .WithMany()
            .HasForeignKey(f => f.OwnerId);

        modelBuilder.Entity<Folder>()
            .HasOne(f => f.Owner)
            .WithMany()
            .HasForeignKey(f => f.OwnerId);
    }
}
