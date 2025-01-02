namespace DUMPDrive.Presentation.Factories;

using DUMPDrive.Domain.Entities;
using DUMPDrive.Data.Repositories;
using DUMPDrive.Domain.Repositories;

public static class RepositoryFactory
{
    public static UserRepository CreateUserRepository()
    {
        return new UserRepository(new List<User>());
    }

    public static FolderRepository CreateFolderRepository()
    {
        return new FolderRepository(new List<Folder>());
    }

    public static FileRepository CreateFileRepository()
    {
        return new FileRepository(new List<FileItem>());
    }

    public static CommentRepository CreateCommentRepository()
    {
        return new CommentRepository(new List<Comment>());
    }
}
