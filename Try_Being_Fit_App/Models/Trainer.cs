using Models.Enums;

namespace Models
{
    public class Trainer : User
    {
        public List<Training> ScheduledTrainings { get; set; }
        public Trainer(int id, string firstName, string lastName, string username, string password, List<Training> scheduledTrainings)
            : base(id, firstName, lastName, username, password, UserRoleEnum.Trainer)
        {
            ScheduledTrainings = new List<Training>();
        }

        public void RescheduledTraining(Training training, DateTime newStartTime)
        {
            if (ScheduledTrainings.Contains(training))
            {
                training.StartTime = newStartTime;
            }
            else
            {
                Console.WriteLine("Trainer is not scheduled for that training.");
            }
        }

        public void Train()
        {
            Console.WriteLine("Training has started!");
        }

        public void LogOut()
        {
            Console.WriteLine($"Trainer {FirstName} logging out.");
        }
    }
}
