using CloudTrader.Mines.Models.API;
using CloudTrader.Mines.Models.Service;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CloudTrader.Mines.Models.Tests.Api
{
    public class MineUpdateModelTests
    {
        [TestCase(null)]
        public void MineUpdateModel_Latitude_CanBeNull(double? latitude)
        {
            var mine = new MineUpdateModel
            {
                Coordinates = new GeographicCoordinates(latitude, 0)
            };

            Assert.IsNull(mine.Coordinates.Latitude);
        }

        [TestCase(46.40750032)]
        public void MineUpdateModel_Latitude_CanBeValidLatitude(double? latitude)
        {
            var mine = new MineUpdateModel
            {
                Coordinates = new GeographicCoordinates(latitude, 0)
            };

            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(mine.Coordinates, new ValidationContext(mine.Coordinates), validationResults, true);

            Assert.True(isValid);
        }

        [TestCase(null)]
        public void MineUpdateModel_Longitude_CanBeNull(double? longitude)
        {
            var mine = new MineUpdateModel
            {
                Coordinates = new GeographicCoordinates(0, longitude)
            };

            Assert.IsNull(mine.Coordinates.Longitude);
        }

        [TestCase(16.92607811)]
        public void MineUpdateModel_Longitude_CanBeValidLongitude(double? latitude)
        {
            var mine = new MineUpdateModel
            {
                Coordinates = new GeographicCoordinates(latitude, 0)
            };

            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(mine.Coordinates, new ValidationContext(mine.Coordinates), validationResults, true);

            Assert.True(isValid);
        }

        [TestCase(null)]
        public void MineUpdateModel_Name_CanBeNull(string name)
        {
            var mine = new MineUpdateModel
            {
                Name = name
            };

            Assert.IsNull(mine.Name);
        }

        [TestCase("Test")]
        public void MineUpdateModel_Name_CanBeValidString(string name)
        {
            var mine = new MineUpdateModel
            {
                Name = name
            };

            Assert.False(string.IsNullOrEmpty(mine.Name));
        }

        [TestCase(null)]
        public void MineUpdateModel_Type_CanBeNull(string type)
        {
            var mine = new MineUpdateModel
            {
                UpdateType = type
            };

            Assert.IsNull(mine.UpdateType);
        }

        [TestCase("externalWeather")]
        public void MineUpdateModel_Type_CanBeValidString(string type)
        {
            var mine = new MineUpdateModel
            {
                UpdateType = type
            };

            Assert.False(string.IsNullOrEmpty(mine.UpdateType));
        }

        [TestCase(null)]
        public void MineUpdateModel_Time_CannotBeNull(DateTime time)
        {
            var mine = new MineUpdateModel
            {
                Time = time
            };

            Assert.IsNotNull(mine.Time);
        }

        [Test]
        public void MineUpdateModel_Time_CanBeValidDateTime()
        {
            var mine = new MineUpdateModel
            {
                Time = new DateTime(2020, 09, 03, 12, 34, 22 )
            };

            var expectedDate = new DateTime(2020, 09, 03, 12, 34, 22);

            Assert.AreEqual(expectedDate, mine.Time);
        }
    }
}
