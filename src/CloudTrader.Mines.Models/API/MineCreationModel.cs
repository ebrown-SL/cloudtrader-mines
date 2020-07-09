using CloudTrader.Mines.Models.Service;
using System.ComponentModel.DataAnnotations;

namespace CloudTrader.Mines.Models.API
{
    public class MineCreationModel
    {
        [Required]
        public GeographicCoordinates Coordinates { get; set; }
    }
}
