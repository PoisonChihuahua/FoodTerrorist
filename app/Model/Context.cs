using Microsoft.EntityFrameworkCore;

namespace FoodTerrorist.Model
{
    public class FoodContext : DbContext
    {
        public DbSet<FoodModel> FoodModel { get; set; }
        public DbSet<UserModel> UserModel { get; set; }
        public DbSet<FoodUserModel> FoodUserModel { get; set; }
        public DbSet<LocationModel> LocationModel { get; set; }
        public FoodContext(DbContextOptions<FoodContext> options) : base(options) { }
    }
}