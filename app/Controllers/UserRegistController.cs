using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using FoodTerrorist.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace FoodTerrorist.Controllers {
    /// <summary>
    /// ユーザ登録コントローラクラス
    /// </summary>
    [ApiController]
    [Route ("api/[controller]")]
    public class UserRegistController : Controller {
        private IConfiguration configuration;
        private ILogger<UserRegistController> logger;
        private readonly FoodContext context;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="configuration">設定</param>
        /// <param name="logger">ロガー</param>
        /// <param name="context">DB</param>
        public UserRegistController (IConfiguration configuration, ILogger<UserRegistController> logger, FoodContext context) {
            this.configuration = configuration;
            this.logger = logger;
            this.context = context;
            context.Database.EnsureCreatedAsync ();
        }

        /// <summary>
        /// ユーザ登録
        /// </summary>
        /// <param name="none">なし</param>
        /// <returns>200：成功</returns>
        [HttpPost]
        public IActionResult RegistUser ([FromBody] UserReg userName) {
            FoodContext fc = context;
            UserModel u = new UserModel ();
            u.LoginId = "999";
            u.Name = userName.userName;
            u.Password = userName.password;
            u.LocationId = 9;
            fc.UserModel.Add (u);
            context.SaveChanges ();
            return Ok ();
        }

        public class UserReg {
            public string userName { get; set; }

            public string password { get; set; }
        };
    }
}