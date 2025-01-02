using DUMPDrive.Domain.Entities;

namespace DUMPDrive.Data.Repositories;

public class CommentRepository
{
    private readonly List<Comment> _comments;

    public CommentRepository(List<Comment> comments)
    {
        _comments = comments;
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public List<Comment> GetCommentsByFileId(int fileId)
    {
        return _comments.Where(c => c.FileItemId == fileId).ToList();
    }
}
