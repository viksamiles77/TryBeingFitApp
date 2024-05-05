using Services.Interfaces;
using DataAccess;
using Models;

namespace Services.Implementations
{
    public class UIService : IUIService
    {
        private StandardUser _registeredUser;
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
                    Console.WriteLine($"Sucessfull Login! Welcome {CurrentSession.CurrentUser.FirstName}.");
                    Console.ForegroundColor = ConsoleColor.White;
                    if (CurrentSession.CurrentUser is StandardUser)
                    {
                        StandardUserMenu();
                    }
                    else if (CurrentSession.CurrentUser is PremiumUser)
                    {
                        PremiumUserMenu();
                    }
                    else if (CurrentSession.CurrentUser is Trainer)
                    {
                        TrainerMenu();
                    }

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
                    var firstName = GetValidFirstName();
                    var lastName = GetValidLastName();
                    var username = GetValidUsername();
                    var password = GetValidPassword();
                    int randomId = _userService.RandomIdGenerator();
                    _registeredUser = _userService.Register(randomId, firstName, lastName, username, password);


                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Successfully created user with username {username}!");
                    Console.ForegroundColor = ConsoleColor.White;
                    StandardUserMenu();
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
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Welcome to the Try Being Fit App!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("1. Login \n2. Register");
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
        public void TrainerMenu()
        {
            string choosedOption;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Please select an option!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1. Reschedule a training \n2. Show account info \n3. Train \n4. Log Out");
            while (true)
            {
                choosedOption = Console.ReadLine();
                if (choosedOption == "1" || choosedOption == "2" || choosedOption == "3" || choosedOption == "4")
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please select a valid option!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            if (choosedOption == "1")
            {
                RescheduleTraining();
                return;
            }
            else if (choosedOption == "2")
            {
                ShowTrainerInfo();
                return;
            }
            else if (choosedOption == "2")
            {
                Train();
                return;
            }
            else if (choosedOption == "2")
            {
                LogOut();
                return;
            }
        }

        public void StandardUserMenu()
        {
            string choosedOption;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Please select an option!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1. Train \n2. Upgrade to premium \n3. Show account info \n4. Log Out");
            while (true)
            {
                choosedOption = Console.ReadLine();
                if (choosedOption == "1" || choosedOption == "2" || choosedOption == "3" || choosedOption == "4")
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please select a valid option!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            if (choosedOption == "1")
            {
                Train();
                return;
            }
            else if (choosedOption == "2")
            {
                if (_registeredUser != null)
                {
                    _userService.UpgradeToPremium(_registeredUser);
                    PremiumUserMenu();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No registered user found!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            else if (choosedOption == "3")
            {
                ShowStandardUserInfo();
                return;
            }
            else if (choosedOption == "4")
            {
                LogOut();
                return;
            }
        }

        public void PremiumUserMenu()
        {
            string choosedOption;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Please select an option!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1. Train \n2. Show account info \n3. Log Out");
            while (true)
            {
                choosedOption = Console.ReadLine();
                if (choosedOption == "1" || choosedOption == "2" || choosedOption == "3")
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please select a valid option!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            if (choosedOption == "1")
            {
                Train();
                return;
            }
            else if (choosedOption == "2")
            {
                ShowPremiumUserInfo();
            }
            else if (choosedOption == "3")
            {
                LogOut();
                return;
            }
        }

        public void RescheduleTraining()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Training rescheduled!");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void ShowTrainerInfo()
        {
            Console.WriteLine($"First name: {CurrentSession.CurrentUser.FirstName}");
            Console.WriteLine($"Last name: {CurrentSession.CurrentUser.LastName}");
            Console.WriteLine($"Username: {CurrentSession.CurrentUser.Username}");
            Console.WriteLine($"Role: {CurrentSession.CurrentUser.Role}");
        }

        public void Train()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You have done a training!");
            Console.ForegroundColor = ConsoleColor.White;
            AskForRating();
            if (CurrentSession.CurrentUser is StandardUser)
            {
                StandardUserMenu();
            }
            else if (CurrentSession.CurrentUser is PremiumUser)
            {
                PremiumUserMenu();
            }
            else if (CurrentSession.CurrentUser is Trainer)
            {
                TrainerMenu();
            }
            _registeredUser.TrainingsAttended ++;
        }

        public void AskForRating()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Please leave a rating for the training!");
            Console.ForegroundColor = ConsoleColor.White;
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out int number))
                {
                    Console.WriteLine($"You gave a rating of: [{number}]");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
        }

        public void LogOut()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Thank you for using our app");
            Console.ForegroundColor = ConsoleColor.White;
            _userService.LogOut();
        }

        public void ShowStandardUserInfo()
        {
            if (_registeredUser != null)
            {
                Console.WriteLine($"First Name: {_registeredUser.FirstName}");
                Console.WriteLine($"Last Name: {_registeredUser.LastName}");
                Console.WriteLine($"Username: {_registeredUser.Username}");
                Console.WriteLine($"Role: {_registeredUser.Role}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No registered user found!");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void ShowPremiumUserInfo()
        {
            Console.WriteLine($"First Name: {_registeredUser.FirstName}");
            Console.WriteLine($"Last Name: {_registeredUser.LastName}");
            Console.WriteLine($"Username: {_registeredUser.Username}");
            Console.WriteLine($"Role: Premium");
        }

        private string GetValidFirstName()
        {
            string firstName;
            do
            {
                Console.Write("First Name: ");
                firstName = Console.ReadLine();
                if (firstName.Length < 2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Your first name must be at least 2 characters long!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            } while (firstName.Length < 2);

            return firstName;
        }

        private string GetValidLastName()
        {
            string lastName;
            do
            {
                Console.Write("Last Name: ");
                lastName = Console.ReadLine();
                if (lastName.Length < 2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Your last name must be at least 2 characters long!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            } while (lastName.Length < 2);

            return lastName;
        }

        private string GetValidUsername()
        {
            string username;
            do
            {
                Console.Write("Username: ");
                username = Console.ReadLine();
                if (username.Length < 6)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Your username must be at least 6 characters long!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            } while (username.Length < 6);

            return username;
        }

        private string GetValidPassword()
        {
            string password;
            do
            {
                Console.Write("Password: ");
                password = Console.ReadLine();
                if (password.Length < 6 || !ContainsNumber(password))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Your password must be at least 6 characters long and include a number!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            } while (password.Length < 6 || !ContainsNumber(password));

            return password;
        }

        private bool ContainsNumber(string str)
        {
            foreach (char c in str)
            {
                if (char.IsDigit(c))
                    return true;
            }
            return false;
        }
    }
}