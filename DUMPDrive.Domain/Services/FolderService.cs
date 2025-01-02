using DUMPDrive.Domain.Entities;

namespace DUMPDrive.Domain.Services;

public class FolderService
{
    private readonly FolderRepository _folderRepository;

    public FolderService(FolderRepository folderRepository)
    {
        _folderRepository = folderRepository;
    }

    public bool CreateFolder(string folderName, int ownerId)
    {
        if (string.IsNullOrWhiteSpace(folderName) || folderName.Length > 100)
            return false;

        return _folderRepository.AddFolder(new Folder
        {
            Name = folderName,
            OwnerId = ownerId
        });
    }

    public List<Folder> GetFoldersForUser(int ownerId)
    {
        return _folderRepository.GetFoldersByOwner(ownerId);
    }
}
