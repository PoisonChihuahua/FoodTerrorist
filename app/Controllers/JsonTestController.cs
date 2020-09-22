using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FoodTerrorist.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Linq;

namespace FoodTerrorist.Controllers
{
    /// <summary>
    /// フードコントローラクラス
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class JsonTestController : Controller
    {
        private IConfiguration configuration;
        private ILogger<FoodController> logger;
        private readonly FoodContext context;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="configuration">設定</param>
        /// <param name="logger">ロガー</param>
        public JsonTestController(IConfiguration configuration, ILogger<FoodController> logger, FoodContext context)
        {
            this.configuration = configuration;
            this.logger = logger;
            this.context = context;
            context.Database.EnsureCreatedAsync();

        }

        /// <summary>
        /// テスト処理
        /// 【成功時】　status_code :200
        /// body :なし
        /// </summary>
        /// <param name="none">なし</param>
        /// <returns>200：成功</returns>
        public IActionResult Get()
        {
            List<Item> IntList = new List<Item>();

            Item item = new Item { Text = "1", Unit = "cm", Value = "あいうえお" };
            IntList.Add(item);
            Item item2 = new Item { Text = "2", Unit = "m", Value = "かきくけこ" };
            IntList.Add(item2);
            Item item3 = new Item { Text = "3", Unit = "km", Value = "さしすせそ" };
            IntList.Add(item3);

            Items items = new Items();
            items.TableHeaders = IntList;
            items.TabelItems = IntList;

            items.sortDic.Add("Key1", "Value1");
            items.sortDic.Add("Key2", "Value2");
            items.sortDic.Add("Key3", "Value3");
            items.sortDic.Add("Key4", "Value4");

            return Json(items, new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                WriteIndented = true,
            });
        }
        public class Item
        {
            public string Text { get; set; }

            public string Unit { get; set; }

            public string Value { get; set; }
        }

        public class Items
        {
            public List<Item> TableHeaders { get; set; }

            public List<Item> TabelItems { get; set; }

            public SortedDictionary<string, string> sortDic { get; set; }

            public Items()
            {
                sortDic = new SortedDictionary<string, string>();
            }
        }

        public class DataItems
        {
            /// <summary>
            /// キー項目
            /// </summary>
            public string Key { get; set; }

            /// <summary>
            /// キー項目値
            /// </summary>
            public string Value { get; set; }
        }
    }
}