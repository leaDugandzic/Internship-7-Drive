namespace DUMPDrive.Presentation.Actions;

using DUMPDrive.Domain.Services;

public static class CommentActions
{
    public static void AddComment(CommentService commentService)
    {
        Console.Write("Enter file ID: ");
        if (int.TryParse(Console.ReadLine(), out var fileId))
        {
            Console.Write("Enter your email: ");
            var email = Console.ReadLine();

            Console.Write("Enter your comment: ");
            var content = Console.ReadLine();

            commentService.AddComment(email!, content!, fileId);
            Console.WriteLine("Comment added successfully!");
        }
        else
        {
            Console.WriteLine("Invalid file ID.");
        }
    }

    public static void ViewComments(CommentService commentService)
    {
        Console.Write("Enter file ID: ");
        if (int.TryParse(Console.ReadLine(), out var fileId))
        {
            var comments = commentService.GetCommentsForFile(fileId);

            Console.WriteLine("Comments:");
            foreach (var comment in comments)
                Console.WriteLine($"- {comment.Email}: {comment.Content} ({comment.Date})");
        }
        else
        {
            Console.WriteLine("Invalid file ID.");
        }
    }
}
