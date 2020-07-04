namespace FoodTerrorist.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using System.Threading.Tasks;

    /// <summary>
    /// ハローワールドコントローラクラス
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class HelloWorldController : Controller
    {
        private IConfiguration configuration;

        private ILogger<HelloWorldController> logger;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="configuration">設定</param>
        /// <param name="logger">ロガー</param>
        public HelloWorldController(IConfiguration configuration, ILogger<HelloWorldController> logger)
        {
            this.configuration = configuration;

            this.logger = logger;
        }

        /// <summary>
        /// テスト処理
        /// 【成功時】　status_code :200
        /// body :なし
        /// </summary>
        /// <param name="none">なし</param>
        /// <returns>200：成功</returns>
        [HttpGet]
        public async Task<ContentResult> Get()
        {
            // コンテンツを返却する
            return Content("An API listing authors of docs.asp.net.");
        }
    }
}