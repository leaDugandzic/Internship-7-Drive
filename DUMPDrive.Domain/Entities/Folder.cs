namespace DUMPDrive.Domain.Entities;

public class Folder
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int UserId { get; set; }
    public User User { get; set; } = null!;
    public List<FileItem> Files { get; set; } = new();
}
