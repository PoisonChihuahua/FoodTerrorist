using System;
using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using FoodTerrorist.Controllers;
using FoodTerrorist.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MockQueryable.Moq;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace Foodterrorist.Tests {
    public class UnitTest1 {
        private readonly ITestOutputHelper _output;
        private readonly Mock<FoodContext> context;

        public UnitTest1 (ITestOutputHelper output) {
            _output = output;
            // mockが返すデータを準備
            var users = new List<UserModel> {
                new UserModel {
                    UserId = 1,
                        LoginId = "1234",
                        Name = "Hoge",
                        Password = "1qaz2wsx",
                        LocationId = 1
                },
                new UserModel {
                    UserId = 2,
                        LoginId = "5678",
                        Name = "Fuga",
                        Password = "1qaz2wsx",
                        LocationId = 2
                }
            }.AsQueryable ();
            var foods = new List<FoodModel> {
                new FoodModel {
                    FoodId = 1,
                        Name = "米"
                },
                new FoodModel {
                    FoodId = 2,
                        Name = "パン"
                }
            }.AsQueryable();
            var mockSetUser = new Mock<DbSet<UserModel>> ();
            mockSetUser.As<IQueryable<UserModel>> ().Setup (m => m.Provider).Returns (users.Provider);
            mockSetUser.As<IQueryable<UserModel>> ().Setup (m => m.Expression).Returns (users.Expression);
            mockSetUser.As<IQueryable<UserModel>> ().Setup (m => m.ElementType).Returns (users.ElementType);
            mockSetUser.As<IQueryable<UserModel>> ().Setup (m => m.GetEnumerator ()).Returns (users.GetEnumerator ());

            var mockSetFood = new Mock<DbSet<FoodModel>>();
            mockSetFood.As<IQueryable<FoodModel>>().Setup(m => m.Provider).Returns(foods.Provider);
            mockSetFood.As<IQueryable<FoodModel>>().Setup(m => m.Expression).Returns(foods.Expression);
            mockSetFood.As<IQueryable<FoodModel>>().Setup(m => m.ElementType).Returns(foods.ElementType);
            mockSetFood.As<IQueryable<FoodModel>>().Setup(m => m.GetEnumerator()).Returns(foods.GetEnumerator());

            context = new Mock<FoodContext> ();
            context.Setup (x => x.UserModel).Returns (mockSetUser.Object);
            context.Setup (x => x.FoodModel).Returns (mockSetFood.Object);
            context.Setup(x => x.SaveChanges()).Returns(mockSetFood.Object.Count());
        }

        [Fact]
        public void Test1 () {
            UserRegistController userRegistController = new UserRegistController (null, null, context.Object);
            Fixture fixture = new Fixture ();
            UserReg usr = fixture.Create<UserReg> ();
            usr.userName = "田中";
            ObjectResult result = (ObjectResult)userRegistController.RegistUser (usr);
            UserModel u = (UserModel)result.Value;
            Assert.Equal(200,result.StatusCode);
            Assert.Equal("田中", u.Name);
        }

        [Theory]
        [InlineData(3, "ラーメン")]
        [InlineData(4, "うどん")]
        [InlineData(1, "米")]
        public void Test2(int foodId, string name)
        {
            FoodController foodCont = new FoodController(null, null, context.Object);
            FoodModel food = new FoodModel{ FoodId = foodId, Name = name};
            OkObjectResult json = (OkObjectResult)foodCont.DeleteFood(food);
            FoodModel returnFood = (FoodModel)json.Value;
            _output.WriteLine($"{returnFood.Name}");
            Assert.Equal(name, returnFood.Name);
        }

        [Fact]
        public void Test3 () {
            Fixture fixture = new Fixture ();
            fixture.Customizations.Add(new NumericSequenceGenerator());
            var sw = new System.Diagnostics.Stopwatch ();
            sw.Start ();
            var users = fixture.Build<UserModel> ()
                .CreateMany (100);
            foreach (var user in users) {
                //_output.WriteLine($"{user.UserId}");
                var fm = users.Where (x => x.UserId == 5).ToList ();
            }
            sw.Stop ();
            _output.WriteLine ($"{ sw.ElapsedMilliseconds } ミリ秒 ");
            Assert.InRange (sw.ElapsedMilliseconds, 1, 10000);
        }

        [Fact]
        public void Test4(){
            FoodController foodController = new FoodController(null, null, context.Object);
            JsonResult json = (JsonResult)foodController.GetFoodAll();
            List<FoodModel> Foods = (List<FoodModel>)json.Value;
            Assert.Equal("米",Foods[0].Name);
            Assert.Equal("パン", Foods[1].Name);
        }
        [Theory]
        [InlineData(1)]
        public void Test5(int id)
        {
            FoodController foodController = new FoodController(null, null, context.Object);
            JsonResult json = (JsonResult)foodController.GetFoodId(id);
            List<FoodModel> Foods = (List<FoodModel>)json.Value;
            Assert.Equal("米", Foods[0].Name);
        }
        [Theory]
        [InlineData("パン")]
        public void Test6(string name)
        {
            FoodController foodController = new FoodController(null, null, context.Object);
            JsonResult json = (JsonResult)foodController.GetFood(name);
            List<FoodModel> Foods = (List<FoodModel>)json.Value;
            Assert.Equal("パン", Foods[0].Name);
        }
        [Theory]
        [InlineData("1234", "1qaz2wsx", "Hoge")]
        [InlineData("5678", "1qaz2wsx", "Fuga")]
        public void Test7(string loginId, string password, string name)
        {
            UserRegistController userRegistController = new UserRegistController(null, null, context.Object);
            UserReg usr = new UserReg();
            usr.loginId = loginId;
            usr.password = password;
            OkObjectResult json = (OkObjectResult)userRegistController.LoginUser(usr);
            List<UserModel> Users = (List<UserModel>)json.Value;
            Assert.Equal(name, Users[0].Name);
        }
        [Theory]
        [InlineData(3, "ラーメン")]
        [InlineData(4, "うどん")]
        [InlineData(1, "米")]
        public void Test8(int foodId, string name)
        {
            FoodController foodCont = new FoodController(null, null, context.Object);
            FoodModel food = new FoodModel();
            food.FoodId = foodId;
            food.Name = name;
            OkObjectResult json = (OkObjectResult)foodCont.AddFood(food);
            FoodModel returnFood = (FoodModel)json.Value;
            _output.WriteLine($"{returnFood.Name}");
            Assert.Equal(name, returnFood.Name);
        }
    }
}