using System.ComponentModel.DataAnnotations;

namespace CloudTrader.Mines.Api.Models
{
    public class MineCreationModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }
    }
}
