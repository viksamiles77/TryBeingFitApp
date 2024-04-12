using Models.Enums;

namespace Models
{
    public class StandardUser : User
    {
        public int TrainingsAttended { get; set; }
        public StandardUser(int id, string firstName, string lastName, string username, string password, UserRoleEnum role, int trainingsAttended) : base(id, firstName, lastName, username, password, role)
        {
            TrainingsAttended = 0;
        }
        public void Train()
        {
            Console.WriteLine("Training has started!");
        }

        public void LogOut()
        {
            Console.WriteLine($"Standard user {FirstName} is logging out.");
        }
    }
}
