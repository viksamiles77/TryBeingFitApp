using Models;

namespace Services.Interfaces
{
    public interface IUserService
    {
        void Register(int id, string firstName, string lastName, string username, string password);
        void Login(string username, string password);
        void UpgradeToPremium(StandardUser standardUser);
    }
}
