using Models.Enums;

namespace Models
{
    public class UserService
    {
        public List<User> users = new List<User>;

        public User AuthenticateUser(string username, string password)
        {
            User user = users.Find(x => x.Username == username);
            if (user != null && user.Password == password)
            {
                Console.WriteLine("Authentication successfull.");
                return user;
            }
            else
            {
                Console.WriteLine("Authentication failed.");
                return null;
            }
        }

        public bool RegisterUser(int id, string firstName, string lastName, string username, string password, UserRoleEnum role)
        {
            if (users.Exists(x => x.Username == username))
            {
                Console.WriteLine("Username already exists.");
                return false;
            }

            User newUser = new User(id, firstName, lastName, username, password, role);
            users.Add(newUser);

            Console.WriteLine("Registration successful.");
            return true;
        }
    }
}
