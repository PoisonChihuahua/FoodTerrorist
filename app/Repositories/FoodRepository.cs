using FoodTerrorist.Model;
using Microsoft.Extensions.Logging;

namespace FoodTerrorist.Repository {
    /// <summary>
    /// フードリポジトリ
    /// </summary>
    public class FoodTerroristRepository {

        private readonly ILogger logger;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="configuration">設定</param>
        /// <param name="logger">ロガー</param>
        public FoodTerroristRepository (ILogger logger) {
            this.logger = logger;
        }

        /// <summary>
        /// 参照
        /// </summary>
        /// <param name="id">なし</param>
        /// <returns>200：成功</returns>
        public FoodModel Get (int id) {
            //string sqlbuff = $"SELECT * FROM {this.schemaName}.m_user WHERE user_id = @UserId";
            //return dbConnection.Query<LoginEntity> (sqlbuff, new { UserId = id }).FirstOrDefault ();
            FoodModel fm = new FoodModel ();
            fm.FoodId = 1;
            fm.Name = "test";
            return fm;
        }
    }
}