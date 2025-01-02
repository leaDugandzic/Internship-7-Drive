namespace DUMPDrive.Presentation.Actions;

using DUMPDrive.Domain.Services;

public static class FolderActions
{
    public static void CreateFolder(FolderService folderService, int userId)
    {
        Console.Write("Enter folder name: ");
        var folderName = Console.ReadLine();

        if (folderService.CreateFolder(folderName!, userId))
            Console.WriteLine("Folder created successfully!");
        else
            Console.WriteLine("Invalid folder name.");
    }

    public static void ListFolders(FolderService folderService, int userId)
    {
        var folders = folderService.GetFoldersForUser(userId);

        if (folders.Count > 0)
        {
            Console.WriteLine("Your folders:");
            foreach (var folder in folders)
                Console.WriteLine($"- {folder.Name}");
        }
        else
        {
            Console.WriteLine("You have no folders.");
        }
    }

    public static void ShowUserOptions(int userId, FolderService folderService, FileService fileService, CommentService commentService)
    {
        while (true)
        {
            Console.WriteLine(@"
Options:
1. Create folder
2. List folders
3. Create file
4. List files in folder
5. Add comment
6. View comments
7. Edit file content
0. Logout
Choose an option: ");

            var action = Console.ReadLine();

            switch (action)
            {
                case "1":
                    CreateFolder(folderService, userId);
                    break;
                case "2":
                    ListFolders(folderService, userId);
                    break;
                case "3":
                    FileActions.CreateFile(fileService);
                    break;
                case "4":
                    FileActions.ListFiles(fileService);
                    break;
                case "5":
                    CommentActions.AddComment(commentService);
                    break;
                case "6":
                    CommentActions.ViewComments(commentService);
                    break;
                case "7":
                    FileActions.EditFileContent(fileService);
                    break;

                case "0":
                    Console.WriteLine("Logged out.");
                    return;

                default:
                    Console.WriteLine("Invalid option. Please select from the menu.");
                    break;
            }
        }
    }
}
