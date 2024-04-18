using Services.Interfaces;
using Services.Implementations;

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
            Console.WriteLine("Please Log In!");
            Console.Write("Username: ");
            var username = Console.ReadLine();

            Console.Write("Password: ");
            var password = Console.ReadLine();

            _userService.Login(username, password);
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
            throw new NotImplementedException();
        }
    }
}
