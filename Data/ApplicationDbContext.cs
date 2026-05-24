using Microsoft.EntityFrameworkCore;
using AppealMaxxWeb.Models;

namespace AppealMaxxWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Meal> Meals { get; set; }

        public DbSet<Workout> Workouts { get; set; }
    }
}