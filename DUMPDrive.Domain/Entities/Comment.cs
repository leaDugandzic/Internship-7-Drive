namespace DUMPDrive.Domain.Entities;

public class Comment
{
    public int Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime Date { get; set; } = DateTime.UtcNow;
    public int FileItemId { get; set; }
    public FileItem FileItem { get; set; } = null!;
}
