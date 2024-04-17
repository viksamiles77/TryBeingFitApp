using Models;
using Models.Enums;
using Services.Interfaces;
using DataAccess.Storage;

namespace Services.Implementations

{
    public class UserService : IUserService
    {
        public void Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public void Register(int id, string firstName, string lastName, string username, string password)
        {
            throw new NotImplementedException();
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
    }
}
