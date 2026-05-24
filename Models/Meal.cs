namespace AppealMaxxWeb.Models
{
    public class Meal
    {
        public int MealId { get; set; }

        public int UserId { get; set; }

        public string MealName { get; set; }

        public int Calories { get; set; }

        public DateTime MealDate { get; set; }

        public User? User { get; set; }
    }
}
