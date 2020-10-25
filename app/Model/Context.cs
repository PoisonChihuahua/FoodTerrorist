using Microsoft.EntityFrameworkCore;

namespace FoodTerrorist.Model {
    public class FoodContext : DbContext {
        public virtual DbSet<FoodModel> FoodModel { get; set; }
        public virtual DbSet<UserModel> UserModel { get; set; }
        public virtual DbSet<FoodUserModel> FoodUserModel { get; set; }
        public virtual DbSet<LocationModel> LocationModel { get; set; }
        public FoodContext (DbContextOptions<FoodContext> options) : base (options) { }
        public FoodContext () { }
    }
}