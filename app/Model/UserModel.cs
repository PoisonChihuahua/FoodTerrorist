using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodTerrorist.Model {
    /// <summary>
    /// ユーザモデルクラス
    /// </summary>
    [Table ("ft_user")]
    public class UserModel {
        /// <summary>
        /// ユーザID
        /// </summary>
        [Key]
        [Column ("user_id")]
        public int UserId { get; set; }

        /// <summary>
        /// ログインID
        /// </summary>
        [Column ("login_id")]
        [StringLength (50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string LoginId { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Column ("name")]
        [StringLength (50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string Name { get; set; }

        /// <summary>
        /// パスワード
        /// </summary>
        [Column ("password")]
        [StringLength (50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string Password { get; set; }

        /// <summary>
        /// 都道府県ID
        /// </summary>
        [Column ("location_id")]
        public int LocationId { get; set; }
    }
}