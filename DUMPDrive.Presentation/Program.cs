using DUMPDrive.Presentation.Actions;
using DUMPDrive.Presentation.Factories;

namespace DUMPDrive.Presentation;

class Program
{
    static void Main(string[] args)
    {
        var services = ServiceFactory.CreateServices();

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
                    UserActions.Login(services.UserService, services.FolderService, services.FileService, services.CommentService);
                    break;

                case "2":
                    UserActions.Register(services.UserService);
                    break;

                case "0":
                    Console.WriteLine("Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid option. Please select numbers from the menu.");
                    break;
            }
        }
    }
}
