namespace DUMPDrive.Domain.Abstractions;

using DUMPDrive.Domain.Entities;

public interface IFolderRepository : IRepository<Folder>
{
    List<Folder> GetFoldersForUser(int userId);
}
