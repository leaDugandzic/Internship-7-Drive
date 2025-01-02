using DUMPDrive.Domain.Entities;

namespace DUMPDrive.Domain.Services;

public class FolderService
{
    private readonly List<Folder> _folders;

    public FolderService(List<Folder> folders)
    {
        _folders = folders;
    }

    public bool CreateFolder(string folderName, int ownerId)
    {
        if (string.IsNullOrWhiteSpace(folderName) || folderName.Length > 100)
            return false;

        var folder = new Folder
        {
            Name = folderName,
            OwnerId = ownerId
        };

        _folders.Add(folder);
        return true;
    }

    public List<Folder> GetUserFolders(int ownerId)
    {
        return _folders.Where(f => f.OwnerId == ownerId).ToList();
    }
}
