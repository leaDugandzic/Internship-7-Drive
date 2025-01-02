namespace DUMPDrive.Domain.Abstractions;

using DUMPDrive.Domain.Entities;

public interface ICommentRepository : IRepository<Comment>
{
    List<Comment> GetCommentsForFile(int fileId);
}
