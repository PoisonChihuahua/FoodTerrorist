using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FoodTerrorist.Model {

    /// <summary>
    /// ロケーションモデルクラス
    /// </summary>
    [Table ("ft_location")]
    public class LocationModel {

        /// <summary>
        /// 都道府県ID
        /// </summary>
        [Key]
        [Column ("location_id")]
        public int LocationId { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Column ("name")]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string Name { get; set; }

    }
}