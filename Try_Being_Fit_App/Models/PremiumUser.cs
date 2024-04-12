using Models.Enums;

namespace Models
{
    public class PremiumUser : User
    {
        public int TrainingsAttended { get; set; }
        public PremiumUser(int id, string firstName, string lastName, string username, string password, UserRoleEnum role, int trainingsAttended)
            : base(id, firstName, lastName, username, password, role)
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
