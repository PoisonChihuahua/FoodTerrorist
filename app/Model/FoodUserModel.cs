using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodTerrorist.Model {
    /// <summary>
    /// フードユーザ関連モデルクラス
    /// </summary>
    [Table("ft_user_food")]
    public class FoodUserModel {
        /// <summary>
        /// ユーザID
        /// </summary>
        [Key]
        [ForeignKey("UserModel")]
        [Column("user_id")]
        public int UserId { get; set; }

        /// <summary>
        /// フードID
        /// </summary>
        [ForeignKey("FoodModel")]
        [Column("food_id")]
        public int FoodId { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Column("name")]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string Name { get; set; }

        /// <summary>
        /// 登録日付
        /// </summary>
        [Column("entry_date")]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string EntryDate { get; set; }

        public virtual UserModel UserModel { get; set; }
        public virtual FoodModel FoodModel { get; set; }
    }
}