using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace CloudTrader.Mines.Models.Service
{
    public class MineUpdateModel
    {
        [SwaggerSchema("The mine coordinates")]
        public GeographicCoordinates Coordinates { get; set; }

        [SwaggerSchema("The mine temperature")]
        public double? Temperature { get; set; }

        [SwaggerSchema("The mine stock")]
        [Range(0, int.MaxValue)]
        public int? Stock { get; set; }

        [SwaggerSchema("The mine location name")]
        public string Name { get; set; }
    }
}

