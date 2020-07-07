using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace CloudTrader.Mines.Api.Models
{
    public class MineCreationModel
    {
        [Key]
        [SwaggerSchema("The mine identifier")]
        public int Id { get; set; }

        [Required]
        [SwaggerSchema("The mine latitude")]
        public double Latitude { get; set; }

        [Required]
        [SwaggerSchema("The mine longitude")]
        public double Longitude { get; set; }

        [Required]
        [SwaggerSchema("The mine location name")]
        public string Name { get; set; }
    }
}
