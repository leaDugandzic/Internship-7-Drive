using DUMPDrive.Domain.Entities;
using DUMPDrive.Data.Repositories;

namespace DUMPDrive.Domain.Services;

public class CommentService
{
    private readonly CommentRepository _commentRepository;

    public CommentService(CommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public void AddComment(string email, string content, int fileId)
    {
        var comment = new Comment
        {
            Email = email,
            Content = content,
            FileItemId = fileId,
            Date = DateTime.Now
        };

        _commentRepository.AddComment(comment);
    }

    public List<Comment> GetCommentsForFile(int fileId)
    {
        return _commentRepository.GetCommentsByFileId(fileId);
    }
}

