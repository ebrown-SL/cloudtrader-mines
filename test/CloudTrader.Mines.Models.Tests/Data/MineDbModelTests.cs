using CloudTrader.Mines.Models.Data;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CloudTrader.Mines.Data.Tests
{
    public class MineDbModelTests
    {
        [TestCase(null)]
        public void Id_CannotBeNull(Guid id)
        {
            var mine = new MineDbModel
            {
                Id = id,
                Longitude = 0,
                Latitude = 0,
                Temperature = 10,
                Stock = 100,
                Name = "Test"
            };

            Assert.IsNotNull(mine.Id);
        }

        [TestCase(null)]
        public void Stock_CannotBeNull(int stock)
        {
            var mine = new MineDbModel
            {
                Id = Guid.NewGuid(),
                Longitude = 0,
                Latitude = 0,
                Temperature = 10,
                Stock = stock,
                Name = "Test"
            };

            Assert.IsNotNull(mine.Stock);
        }

        [TestCase(null)]
        public void Longitude_CannotBeNull(double longitude)
        {
            var mine = new MineDbModel
            {
                Id = Guid.NewGuid(),
                Longitude = longitude,
                Latitude = 0,
                Temperature = 10,
                Stock = 0,
                Name = "Test"
            };

            Assert.IsNotNull(mine.Longitude);
        }

        [TestCase(null)]
        public void Latitude_CannotBeNull(double latitude)
        {
            var mine = new MineDbModel
            {
                Id = Guid.NewGuid(),
                Longitude = 0,
                Latitude = latitude,
                Temperature = 10,
                Stock = 0,
                Name = "Test"
            };

            Assert.IsNotNull(mine.Latitude);
        }

        [TestCase(null)]
        public void Tempetature_CannotBeNull(double temperature)
        {
            var mine = new MineDbModel
            {
                Id = Guid.NewGuid(),
                Longitude = 0,
                Latitude = 0,
                Temperature = temperature,
                Stock = 0,
                Name = "Test"
            };

            Assert.IsNotNull(mine.Temperature);
        }

        [Test]
        public void Stock_Zero_isValid()
        {
            var mine = new MineDbModel
            {
                Id = Guid.NewGuid(),
                Longitude = 0,
                Latitude = 0,
                Temperature = 10,
                Stock = 0,
                Name = "Test"
            };

            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(mine, new ValidationContext(mine), validationResults, true);

            Assert.True(isValid);
        }

        [Test]
        public void Stock_Negative_isNotValid()
        {
            var mine = new MineDbModel
            {
                Id = Guid.NewGuid(),
                Longitude = 0,
                Latitude = 0,
                Temperature = 10,
                Stock = -1,
                Name = "Test"
            };

            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(mine, new ValidationContext(mine), validationResults, true);

            Assert.False(isValid);
        }
    }
}