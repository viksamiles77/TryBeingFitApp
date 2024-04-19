using Models.Enums;

namespace Models
{
    public abstract class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public UserRoleEnum Role { get; set; }
        public User(int id, string firstName, string lastName, string username, string password, UserRoleEnum role)
            : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Password = password;
            Role = role;
        }
        public void SetPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Password is required");
            }

            if (password.Length < 8)
            {
                throw new ArgumentException("Password must be at least 8 characters long.");
            }

            Password = password;
        }

        public bool CheckPassword(string password)
        {
            return Password == password;
        }
    }

}
