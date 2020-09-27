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
    /// フードコントローラクラス
    /// </summary>
    [ApiController]
    [Route ("api/[controller]")]
    public class FoodController : Controller {
        private IConfiguration configuration;
        private ILogger<FoodController> logger;
        private readonly FoodContext context;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="configuration">設定</param>
        /// <param name="logger">ロガー</param>
        /// <param name="context">DB</param>
        public FoodController (IConfiguration configuration, ILogger<FoodController> logger, FoodContext context) {
            this.configuration = configuration;
            this.logger = logger;
            this.context = context;
        }

        /// <summary>
        /// フード検索(部分一致)
        /// </summary>
        /// <param name="none">なし</param>
        /// <returns>200：成功</returns>
        [HttpGet]
        public IActionResult GetFoodAll () {
            FoodContext fc = context;
            // 出力テスト
            // foreach (FoodModel FoodModel in fc.FoodModel) {
            //     Console.WriteLine ("id:{0}, name:{1}", FoodModel.FoodId, FoodModel.Name);
            // }
            // foreach (LocationModel LocationModel in fc.LocationModel) {
            //     Console.WriteLine ("id:{0}, name:{1}", LocationModel.LocationId, LocationModel.Name);
            // }
            // foreach (UserModel UserModel in fc.UserModel) {
            //     Console.WriteLine ("id:{0}, login_id:{1}, name:{2}, password:{3}", UserModel.UserId, UserModel.LoginId, UserModel.Name, UserModel.Password);
            // }
            IEnumerable<FoodModel> fm;
            fm = fc.FoodModel;
            return Json (fm, new JsonSerializerOptions {
                Encoder = JavaScriptEncoder.Create (UnicodeRanges.All),
                    WriteIndented = true,
            });
        }

        /// <summary>
        /// フード検索(部分一致)
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns>200：成功</returns>
        [HttpGet ("name")]
        public IActionResult GetFood (string name) {
            FoodContext fc = context;
            // 出力テスト
            // foreach (FoodModel FoodModel in fc.FoodModel) {
            //     Console.WriteLine ("id:{0}, name:{1}", FoodModel.FoodId, FoodModel.Name);
            // }
            // foreach (LocationModel LocationModel in fc.LocationModel) {
            //     Console.WriteLine ("id:{0}, name:{1}", LocationModel.LocationId, LocationModel.Name);
            // }
            // foreach (UserModel UserModel in fc.UserModel) {
            //     Console.WriteLine ("id:{0}, login_id:{1}, name:{2}, password:{3}", UserModel.UserId, UserModel.LoginId, UserModel.Name, UserModel.Password);
            // }
            IEnumerable<FoodModel> fm;
            fm = fc.FoodModel.Where (x => x.Name.Contains (name));
            return Json (fm, new JsonSerializerOptions {
                Encoder = JavaScriptEncoder.Create (UnicodeRanges.All),
                    WriteIndented = true,
            });
        }

        /// <summary>
        /// フードID検索
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>200：成功</returns>
        [HttpGet ("id")]
        public IActionResult GetFoodId (int id) {
            FoodContext fc = context;
            IEnumerable<FoodModel> fm;
            fm = fc.FoodModel.Where (x => x.FoodId == id);
            return Json (fm, new JsonSerializerOptions {
                Encoder = JavaScriptEncoder.Create (UnicodeRanges.All),
                    WriteIndented = true,
            });
        }
    }
}