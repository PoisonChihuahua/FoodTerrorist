using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FoodTerrorist.Model {

    /// <summary>
    /// フードモデルクラス
    /// </summary>
    [Table ("ft_food")]
    public class FoodModel {

        /// <summary>
        /// フードID
        /// </summary>
        [Key]
        [Column ("food_id")]
        public int FoodId { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Column ("name")]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string Name { get; set; }

    }
}