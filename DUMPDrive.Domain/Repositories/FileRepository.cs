using DUMPDrive.Domain.Entities;

public class FileRepository
{
    private readonly List<FileItem> _files;

    public FileRepository(List<FileItem> files)
    {
        _files = files;
    }

    public bool AddFile(FileItem file)
    {
        _files.Add(file);
        return true;
    }

    public List<FileItem> GetFilesByFolder(int folderId)
    {
        return _files.Where(f => f.FolderId == folderId).ToList();
    }
}
