using DUMPDrive.Domain.Entities;

namespace DUMPDrive.Domain.Repositories;

public interface IFileRepository
{
    bool Add(FileItem file);
    List<FileItem> GetFilesByFolderId(int folderId);
    bool EditFileContent(int fileId, string newContent);
}
