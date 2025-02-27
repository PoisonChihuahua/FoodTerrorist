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
            u.LoginId = userName.loginId;
            u.Name = userName.userName;
            u.Password = userName.password;
            try {
                fc.UserModel.Add (u);
                context.SaveChanges ();

            } catch (Exception e) {
                Console.WriteLine (e.ToString ());
                return BadRequest(u);
            }
            return Ok (u);
        }
        /// <summary>
        /// ログイン
        /// </summary>
        /// <param name="none">なし</param>
        /// <returns>200：成功</returns>
        [HttpGet]
        public IActionResult LoginUser([FromBody] UserReg userName)
        {
            FoodContext fc = context;
            IEnumerable<UserModel> fm = fc.UserModel.Where(x => x.LoginId.Contains(userName.loginId) && x.Password.Contains(userName.password)).ToList();
            if( fm.Count() == 0 )
            {
                return BadRequest();
            }
            return Ok(fm);
        }
    }
    public class UserReg {
        public string userName { get; set; }
        public string password { get; set; }
        public string loginId { get; set; }
    };
}