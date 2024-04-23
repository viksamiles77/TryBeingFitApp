using Models;
using System.Diagnostics;

namespace DataAccess
{
    public static class Storage
    {
        public static List<Training> ScheduledTraining = new List<Training>();
        public static StorageSet<StandardUser> StandardUsers = new StorageSet<StandardUser>();
        public static StorageSet<PremiumUser> PremiumUsers = new StorageSet<PremiumUser>();
        public static StorageSet<Trainer> Trainers = new StorageSet<Trainer>();
        public static StorageSet<User> Users { get; set; } = new StorageSet<User>()
        {
            Items = new List<User>() { new Trainer(0, "Viktor", "Mileski", "viksa", "trainer123", ScheduledTraining) }
        };
    }
}
