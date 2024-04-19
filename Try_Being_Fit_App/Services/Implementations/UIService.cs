using Services.Interfaces;
using DataAccess;

namespace Services.Implementations
{
    public class UIService : IUIService
    {
        private IUserService _userService;

        public UIService()
        {
            _userService = new UserService();
        }

        public void Login()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Please Log In!");
                    Console.Write("Username: ");
                    var username = Console.ReadLine();

                    Console.Write("Password: ");
                    var password = Console.ReadLine();

                    _userService.Login(username, password);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Sucessfull Login! Welcome {CurrentSession.CurrentUser.FirstName} - [{CurrentSession.CurrentUser.Role}]");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Please try again!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }

        public void Register()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Please register!");
                    Console.Write("First Name: ");
                    var firstName = Console.ReadLine();
                    Console.Write("Last Name: ");
                    var lastName = Console.ReadLine();
                    Console.Write("Username: ");
                    var username = Console.ReadLine();
                    Console.Write("Password: ");
                    var password = Console.ReadLine();
                    int randomId = _userService.RandomIdGenerator();
                    _userService.Register(randomId, firstName, lastName, username, password);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Successfully created user with username {username}!");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Please try again!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }

        public void ShowMenu()
        {
            string choosedOption;
            if (CurrentSession.CurrentUser == null)
            {
                Console.WriteLine("Choose an option! (1 or 2)");
                Console.WriteLine("1. Login \n2.Register");
                while (true)
                {
                    choosedOption = Console.ReadLine();
                    if (choosedOption == "1" || choosedOption == "2")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input, please select 1 or 2");
                    }
                }
                if (choosedOption == "1")
                {
                    Login();
                    return;
                }
                else if (choosedOption == "2")
                {
                    Register();
                    return;
                }
            }
        }
    }
}
