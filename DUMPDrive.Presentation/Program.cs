using DUMPDrive.Domain.Entities;
using DUMPDrive.Domain.Services;

var userService = new UserService(new List<User>());
var folderService = new FolderService(new List<Folder>()); 

while (true)
{
    Console.WriteLine(@"
Welcome to DUMP Drive!
1. Login
2. Register
0. Exit
Select an option: ");

    var option = Console.ReadLine();

    switch (option)
    {
        case "1": 
            Console.Write("Email: ");
            var loginEmail = Console.ReadLine();

            Console.Write("Password: ");
            var loginPassword = Console.ReadLine();

            var user = userService.Authenticate(loginEmail!, loginPassword!);

            if (user != null)
            {
                Console.WriteLine("Login successful!");
                while (true)
                {
                    Console.WriteLine("\nOptions:");
                    Console.WriteLine("1. Create folder");
                    Console.WriteLine("2. List folders");
                    Console.WriteLine("0. Logout");
                    Console.Write("Choose an option: ");
                    var action = Console.ReadLine();

                    if (action == "1")
                    {
                        Console.Write("Enter folder name: ");
                        var folderName = Console.ReadLine();

                        if (folderService.CreateFolder(folderName!, user.Id))
                            Console.WriteLine("Folder created successfully!");
                        else
                            Console.WriteLine("Invalid folder name.");
                    }
                    else if (action == "2")
                    {
                        var folders = folderService.GetUserFolders(user.Id);

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
                    else if (action == "0")
                    {
                        Console.WriteLine("Logged out.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid option. Please select from the menu.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid credentials.");
            }
            break;

        case "2": 
            Console.Write("Email: ");
            var registerEmail = Console.ReadLine();

            Console.Write("Password: ");
            var registerPassword = Console.ReadLine();

            if (userService.Register(registerEmail!, registerPassword!))
                Console.WriteLine("Registration successful!");
            else
                Console.WriteLine("Email already exists.");
            break;

        case "0": 
            Console.WriteLine("Goodbye!");
            return; 

        default: 
            Console.WriteLine("Invalid option. Please select numbers from menu.");
            break;
    }
}
