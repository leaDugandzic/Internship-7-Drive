namespace DUMPDrive.Domain.Entities;

public class FileItem
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime LastChanged { get; set; } = DateTime.UtcNow;
    public int FolderId { get; set; }
    public Folder Folder { get; set; } = null!;
    public int OwnerId { get; set; }  
    public User Owner { get; set; } = null!; 
    public string Content { get; set; } = string.Empty;
    public List<Comment> Comments { get; set; } = new();
}
