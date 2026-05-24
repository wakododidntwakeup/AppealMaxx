namespace AppealMaxxWeb.Models
{
    public class Workout
    {
        public int WorkoutId { get; set; }

        public int UserId { get; set; }

        public string WorkoutName { get; set; }

        public int DurationMinutes { get; set; }

        public int BurnedCalories { get; set; }

        public DateTime WorkoutDate { get; set; }

        public User? User { get; set; }
    }
}
