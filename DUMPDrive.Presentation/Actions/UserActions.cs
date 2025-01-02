namespace DUMPDrive.Presentation.Actions;

using DUMPDrive.Domain.Services;

public static class UserActions
{
    public static void Login(UserService userService, FolderService folderService, FileService fileService, CommentService commentService)
    {
        Console.Write("Email: ");
        var email = Console.ReadLine();

        Console.Write("Password: ");
        var password = Console.ReadLine();

        var user = userService.Authenticate(email!, password!);

        if (user != null)
        {
            Console.WriteLine("Login successful!");
            FolderActions.ShowUserOptions(user.Id, folderService, fileService, commentService);
        }
        else
        {
            Console.WriteLine("Invalid credentials.");
        }
    }

    public static void Register(UserService userService)
    {
        Console.Write("Email: ");
        var email = Console.ReadLine();

        Console.Write("Password: ");
        var password = Console.ReadLine();

        if (userService.Register(email!, password!))
        {
            Console.WriteLine("Registration successful!");
        }
        else
        {
            Console.WriteLine("Email already exists.");
        }
    }
}
