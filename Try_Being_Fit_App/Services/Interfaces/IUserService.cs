using Models;

namespace Services.Interfaces
{
    public interface IUserService
    {
        StandardUser Register(int id, string firstName, string lastName, string username, string password);
        void Login(string username, string password);
        PremiumUser UpgradeToPremium(StandardUser standardUser);
        int RandomIdGenerator();
        void LogOut();
    }
}
