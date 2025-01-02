using DUMPDrive.Domain.Entities;

namespace DUMPDrive.Domain.Services;

public class FileService
{
    private readonly FileRepository _fileRepository;

    public FileService(FileRepository fileRepository)
    {
        _fileRepository = fileRepository;
    }

    public bool CreateFile(string fileName, string content, int folderId)
    {
        if (string.IsNullOrWhiteSpace(fileName) || fileName.Length > 50)
            return false;

        return _fileRepository.AddFile(new FileItem
        {
            Name = fileName,
            Content = content,
            FolderId = folderId,
            LastChanged = DateTime.Now
        });
    }

    public List<FileItem> GetFilesInFolder(int folderId)
    {
        return _fileRepository.GetFilesByFolder(folderId);
    }
}
