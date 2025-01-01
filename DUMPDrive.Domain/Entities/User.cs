﻿namespace DUMPDrive.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public List<Folder> Folders { get; set; } = new();
    public List<FileItem> SharedFiles { get; set; } = new();
}
