using System;
using System.ComponentModel.DataAnnotations;

namespace CloudTrader.Mines.Models.Data
{
    public class MineDbModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public double? Latitude { get; set; }

        [Required]
        public double? Longitude { get; set; }

        [Required]
        public double? Temperature { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int? Stock { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime Time { get; set; }

        [Required]
        public UpdateType Type { get; set; }
    }
}
