using Models.Enums;

namespace Models
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public UserRoleEnum Role { get; set; }
        public User(int id, string firstName, string lastName, string username, string password, UserRoleEnum role) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Password = password;
            Role = role;
        }
    }
}
