using CloudTrader.Mines.Models.Data;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace CloudTrader.Mines.Models.Service
{
    public class MineUpdateModel
    {
        [SwaggerSchema("The mine coordinates")]
        public GeographicCoordinates? Coordinates { get; set; }

        [SwaggerSchema("The mine temperature")]
        public double? Temperature { get; set; }

        [SwaggerSchema("The mine stock")]
        [Range(0, int.MaxValue)]
        public int? Stock { get; set; }

        [SwaggerSchema("The mine location name")]
        public string? Name { get; set; }

        [SwaggerSchema("The type of update")]
        public UpdateType UpdateType
        {
            get => updateType;
            set
            {
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

        [SwaggerSchema("The date and time of the update")]
        public DateTime Time { get; set; }
    }
}