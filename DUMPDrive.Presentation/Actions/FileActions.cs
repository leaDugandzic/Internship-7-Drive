namespace DUMPDrive.Presentation.Actions;

using DUMPDrive.Domain.Services;

public static class FileActions
{
    public static void CreateFile(FileService fileService)
    {
        Console.Write("Enter folder ID: ");
        if (int.TryParse(Console.ReadLine(), out var folderId))
        {
            Console.Write("Enter file name: ");
            var fileName = Console.ReadLine();

            Console.Write("Enter file content: ");
            var content = Console.ReadLine();

            if (fileService.CreateFile(fileName!, content!, folderId))
                Console.WriteLine("File created successfully!");
            else
                Console.WriteLine("Invalid file name or folder ID.");
        }
        else
        {
            Console.WriteLine("Invalid folder ID.");
        }
    }

    public static void ListFiles(FileService fileService)
    {
        Console.Write("Enter folder ID: ");
        if (int.TryParse(Console.ReadLine(), out var folderId))
        {
            var files = fileService.GetFilesInFolder(folderId);

            if (files.Count > 0)
            {
                Console.WriteLine("Files in folder:");
                foreach (var file in files)
                    Console.WriteLine($"- {file.Name} (Last changed: {file.LastChanged})");
            }
            else
            {
                Console.WriteLine("No files found in this folder.");
            }
        }
        else
        {
            Console.WriteLine("Invalid folder ID.");
        }
    }

    public static void EditFileContent(FileService fileService)
    {
        Console.Write("Enter file ID: ");
        if (int.TryParse(Console.ReadLine(), out var fileId))
        {
            Console.Write("Enter new file content: ");
            var newContent = Console.ReadLine();

            if (fileService.EditFileContent(fileId, newContent!))
                Console.WriteLine("File content updated successfully!");
            else
                Console.WriteLine("Invalid file ID or content.");
        }
        else
        {
            Console.WriteLine("Invalid file ID.");
        }
    }
}
