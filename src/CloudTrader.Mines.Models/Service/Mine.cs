﻿using System.ComponentModel.DataAnnotations;

namespace CloudTrader.Mines.Models.Service
{
    public class Mine
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public GeographicCoordinates Coordinates { get; set; }

        [Required]
        public double Temperature { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Stock { get; set; }
    }
}