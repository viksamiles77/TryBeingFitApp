using Models;
namespace Services.Interfaces
{
    public interface IUIService
    {
        void Register();
        void Login();
        void LogOut();
        void ShowMenu();
        void TrainerMenu();
        void StandardUserMenu();
        void PremiumUserMenu();
        void RescheduleTraining();
        void ShowTrainerInfo();
        void ShowStandardUserInfo();
        void ShowPremiumUserInfo();
        void Train();
    }
}
