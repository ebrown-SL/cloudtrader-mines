using System.ComponentModel.DataAnnotations;

namespace CloudTrader.Mines.Service
{
    public class Mine
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }

        [Required]
        public double Temperature { get; set; }

        [Required]
        [Range(0, 100)]
        public int Stock { get; set; }
    }
}