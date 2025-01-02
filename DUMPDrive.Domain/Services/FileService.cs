using DUMPDrive.Domain.Repositories;
using DUMPDrive.Domain.Entities;
using DUMPDrive.Domain.Abstractions;

namespace DUMPDrive.Domain.Services;

public class FileService
{
    private readonly IFileRepository _fileRepository;

    public FileService(IFileRepository fileRepository)
    {
        _fileRepository = fileRepository;
    }

    public bool CreateFile(string name, string content, int folderId)
    {
        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(content))
            return false;

        var file = new FileItem
        {
            Name = name,
            Content = content,
            FolderId = folderId,
            LastChanged = DateTime.Now
        };

        return _fileRepository.Add(file);
    }

    public List<FileItem> GetFilesInFolder(int folderId)
    {
        return _fileRepository.GetFilesByFolderId(folderId);
    }

    public bool EditFileContent(int fileId, string newContent)
    {
        return _fileRepository.EditFileContent(fileId, newContent);
    }
}
