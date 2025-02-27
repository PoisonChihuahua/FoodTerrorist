using System.Linq;
using FoodTerrorist.Model;

namespace FoodTerrorist.Controllers {
    public static class DbInitializer {
        public static void Initialize (FoodContext context) {
            context.Database.EnsureCreated ();

            if (context.FoodModel.Any ()) {
                return; // DB has been seeded
            }

            var foods = new FoodModel[] {
                new FoodModel { FoodId = 1, Name = "米" },
                new FoodModel { FoodId = 2, Name = "パン" },
                new FoodModel { FoodId = 3, Name = "パスタ" },
                new FoodModel { FoodId = 4, Name = "そば" },
                new FoodModel { FoodId = 5, Name = "うどん" },
                new FoodModel { FoodId = 6, Name = "ラーメン" },
            };

            context.FoodModel.AddRange (foods);
            context.SaveChanges ();

            var locations = new LocationModel[] {
                new LocationModel { LocationId = 1, Name = "北海道" },
                new LocationModel { LocationId = 2, Name = "東京" },
                new LocationModel { LocationId = 3, Name = "沖縄" },
            };

            context.LocationModel.AddRange (locations);
            context.SaveChanges ();

            var users = new UserModel[] {
                new UserModel { UserId = 1, LoginId = "test1", Name = "テスト1", Password = "1qaz2wsx", LocationId = 1 },

            };

            context.UserModel.AddRange (users);
            context.SaveChanges ();

            var foodUsers = new FoodUserModel[] {
                new FoodUserModel { UserId = 1, FoodId = 1, Name = "フード1", EntryDate = "20200814" },
            };

            context.FoodUserModel.AddRange (foodUsers);
            context.SaveChanges ();

        }
    }
}