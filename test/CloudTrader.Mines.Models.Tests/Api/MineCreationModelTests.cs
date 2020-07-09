using CloudTrader.Mines.Models.API;
using CloudTrader.Mines.Models.Service;
using NUnit.Framework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CloudTrader.Mines.Api.Tests.Models
{
    public class MineCreationModelTests
    {
        [TestCase(null)]
        public void MineCreationModel_Latitude_CannotBeNull(double? latitude)
        {
            var mine = new MineCreationModel
            {
                Coordinates = new GeographicCoordinates(latitude, 0)
            };

            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(mine.Coordinates, new ValidationContext(mine.Coordinates), validationResults, true);

            Assert.False(isValid);
        }

        [TestCase(46.40750032)]
        public void MineCreationModel_Latitude_CanBeValidLatitude(double? latitude)
        {
            var mine = new MineCreationModel
            {
                Coordinates = new GeographicCoordinates(latitude, 0)
            };

            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(mine.Coordinates, new ValidationContext(mine.Coordinates), validationResults, true);

            Assert.True(isValid);
        }

        [TestCase(null)]
        public void MineCreationModel_Longitude_CannotBeNull(double? longitude)
        {
            var mine = new MineCreationModel
            {
                Coordinates = new GeographicCoordinates(0, longitude)
            };

            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(mine.Coordinates, new ValidationContext(mine.Coordinates), validationResults, true);

            Assert.False(isValid);
        }

        [TestCase(16.92607811)]
        public void MineCreationModel_Longitude_CanBeValidLongitude(double? latitude)
        {
            var mine = new MineCreationModel
            {
                Coordinates = new GeographicCoordinates(latitude, 0)
            };

            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(mine.Coordinates, new ValidationContext(mine.Coordinates), validationResults, true);

            Assert.True(isValid);
        }
    }
}
