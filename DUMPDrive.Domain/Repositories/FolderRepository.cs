using DUMPDrive.Domain.Entities;

public class FolderRepository
{
    private readonly List<Folder> _folders;

    public FolderRepository(List<Folder> folders)
    {
        _folders = folders;
    }

    public bool AddFolder(Folder folder)
    {
        folder.Id = _folders.Count + 1;
        _folders.Add(folder);
        return true;
    }

    public List<Folder> GetFoldersByOwner(int ownerId)
    {
        return _folders.Where(f => f.OwnerId == ownerId).ToList();
    }
}
