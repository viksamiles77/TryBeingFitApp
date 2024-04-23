using Models;
using Services.Interfaces;
using DataAccess;

namespace Services.Implementations
{

    public class UserService : IUserService
    {
        public void Login(string username, string password)
        {
            var loginUser = Storage.Users.GetAll().FirstOrDefault(x => x.Username == username);
            if (loginUser == null)
            {
                throw new Exception("User not found");
            }
            if (!loginUser.CheckPassword(password))
            {
                throw new Exception("Wrong password!");
            };

            CurrentSession.CurrentUser = loginUser;
        }


        public StandardUser Register(int id, string firstName, string lastName, string username, string password)
        {
            if (Storage.StandardUsers.GetAll().Any(x => x.Username == username) ||
                Storage.PremiumUsers.GetAll().Any(x => x.Username == username) ||
                Storage.Trainers.GetAll().Any(x => x.Username == username))
            {
                throw new Exception($"Username with username {username}. already exists!");
            }
            var newUser = new StandardUser(id, firstName, lastName, username, password, 0);
            Storage.StandardUsers.Add(newUser);
            return newUser;
        }

        public PremiumUser UpgradeToPremium(StandardUser standardUser)
        {
            PremiumUser premiumUser = new PremiumUser(
                standardUser.Id,
                standardUser.FirstName,
                standardUser.LastName,
                standardUser.Username,
                standardUser.Password,
                standardUser.TrainingsAttended
                );


            Storage.StandardUsers.Delete(standardUser);

            Storage.PremiumUsers.Add(premiumUser);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Upgrade to premium successful.");
            Console.ForegroundColor = ConsoleColor.White;

            return premiumUser;
        }
        public int RandomIdGenerator()
        {
            Random random = new Random();
            return random.Next(1, 1000);

        }

        public void LogOut()
        {
            CurrentSession.CurrentUser = null;
        }
    }
}
