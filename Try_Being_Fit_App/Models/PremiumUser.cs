using Models.Enums;

namespace Models
{
    public class PremiumUser : User
    {
        public int TrainingsAttended { get; set; }
        public PremiumUser(int id, string firstName, string lastName, string username, string password, int trainingsAttended)
            : base(id, firstName, lastName, username, password, UserRoleEnum.Premium)
        {
            TrainingsAttended = 0;
        }

        public void Train()
        {
            Console.WriteLine("Training has started!");
        }

        public void LogOut()
        {
            Console.WriteLine($"Premium user {FirstName} is logging out.");
        }
    }
}
