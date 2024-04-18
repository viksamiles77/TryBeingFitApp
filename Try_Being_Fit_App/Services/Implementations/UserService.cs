using Models;
using Models.Enums;
using Services.Interfaces;
using DataAccess.Storage;
using DataAccess;
using System.Data.SqlTypes;
using System.Net.Http.Headers;

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


        public void Register(int id, string firstName, string lastName, string username, string password)
        {
            if (Storage.StandardUsers.GetAll().Any(x => x.Username == username) ||
                Storage.PremiumUsers.GetAll().Any(x => x.Username == username) ||
                Storage.Trainers.GetAll().Any(x => x.Username == username))
            {
                throw new Exception($"Username with username {username}. already exists!");
            }
            var newUser = new StandardUser(id, firstName, lastName, username, password, 0);
            Storage.StandardUsers.Add(newUser);
        }

        public void UpgradeToPremium(StandardUser standardUser)
        {
            PremiumUser premiumUser = new PremiumUser(
                standardUser.Id,
                standardUser.FirstName,
                standardUser.LastName,
                standardUser.Username,
                standardUser.Password,
                standardUser.TrainingsAttended
                );


            StandardUsers.Delete(standardUser);

            PremiumUsers.Add(premiumUser);

            Console.WriteLine("Upgrade to premium successful.");
        }
        public int RandomIdGenerator()
        {
            Random random = new Random();
            return random.Next(1, 1000);

        }
    }
}
