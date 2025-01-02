using DUMPDrive.Domain.Entities;
using DUMPDrive.Domain.Services;

var userService = new UserService(new List<User>());

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
                Console.WriteLine("Login successful!");
            else
                Console.WriteLine("Invalid credentials.");
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
