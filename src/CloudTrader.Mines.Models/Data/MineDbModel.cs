using System;
using System.ComponentModel.DataAnnotations;

namespace CloudTrader.Mines.Models.Data
{
    #nullable enable
    public class MineDbModel
    {
        [Key]
        public Guid Id { get; set; }

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
        public string? Name { get; set; }

        [Required]
        public DateTime Time { get; set; }

        [Required]
        public UpdateType UpdateType
        {
            get => updateType;
            set {
                if (!(value == UpdateType.trade || value == UpdateType.weather))
                {
                    throw new System.ArgumentException("UpdateType is invalid");
                }
                else
                {
                    updateType = value;
                }
            }
        }

        private UpdateType updateType;
    }
#nullable restore
}
