using DUMPDrive.Domain.Abstractions;
using DUMPDrive.Domain.Entities;

namespace DUMPDrive.Domain.Repositories;

public class FileRepository : IFileRepository
{
    private readonly List<FileItem> _files;

    public FileRepository(List<FileItem> files)
    {
        _files = files;
    }

    public bool Add(FileItem file)
    {
        if (file == null || string.IsNullOrWhiteSpace(file.Name))
            return false;

        file.Id = _files.Count + 1;
        _files.Add(file);
        return true;
    }

    public List<FileItem> GetFilesByFolderId(int folderId)
    {
        return _files.Where(f => f.FolderId == folderId).ToList();
    }

    public bool EditFileContent(int fileId, string newContent)
    {
        var file = _files.FirstOrDefault(f => f.Id == fileId);
        if (file == null || string.IsNullOrWhiteSpace(newContent))
            return false;

        file.Content = newContent;
        file.LastChanged = DateTime.Now;
        return true;
    }
}
