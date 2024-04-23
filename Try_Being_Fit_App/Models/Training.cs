using Models.Enums;

namespace Models
{
    public class Training
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public TrainingTypeEnum Type { get; set; }
        public int Rating { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; } // video trainings can be null (we can watch them anytime).

        public Trainer AssignedTrainer { get; set; }

        public Training(string title, string description, TrainingTypeEnum type, int rating, DateTime startTime, DateTime? endTime, Trainer assignedTrainer)
        {
            Title = title;
            Description = description;
            Type = type;
            Rating = 0; // default / starting rating
            StartTime = startTime;
            EndTime = endTime;
            AssignedTrainer = assignedTrainer;
        }
    }
}
