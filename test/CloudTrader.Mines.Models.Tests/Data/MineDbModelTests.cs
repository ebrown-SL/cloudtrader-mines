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
        public void Id_CannotBeNull(int id)
        {
            var mine = new MineDbModel
            {
                Id = id,
                Longitude = 0,
                Latitude = 0,
                Temperature = 10,
                Stock = 100,
                Name = "Test",
                Time = DateTime.Now,
                UpdateType = "trade"
            };

            Assert.IsNotNull(mine.Id);
        }

        [TestCase(null)]
        public void Stock_CannotBeNull(int stock)
        {
            var mine = new MineDbModel
            {
                Id = 1,
                Longitude = 0,
                Latitude = 0,
                Temperature = 10,
                Stock = stock,
                Name = "Test",
                Time = DateTime.Now,
                UpdateType = "trade"
            };

            Assert.IsNotNull(mine.Stock);
        }

        [TestCase(null)]
        public void Longitude_CannotBeNull(double longitude)
        {
            var mine = new MineDbModel
            {
                Id = 1,
                Longitude = longitude,
                Latitude = 0,
                Temperature = 10,
                Stock = 0,
                Name = "Test",
                Time = DateTime.Now,
                UpdateType = "trade"
            };

            Assert.IsNotNull(mine.Longitude);
        }

        [TestCase(null)]
        public void Latitude_CannotBeNull(double latitude)
        {
            var mine = new MineDbModel
            {
                Id = 1,
                Longitude = 0,
                Latitude = latitude,
                Temperature = 10,
                Stock = 0,
                Name = "Test",
                Time = DateTime.Now,
                UpdateType = "trade"
            };

            Assert.IsNotNull(mine.Latitude);
        }

        [TestCase(null)]
        public void Tempetature_CannotBeNull(double temperature)
        {
            var mine = new MineDbModel
            {
                Id = 1,
                Longitude = 0,
                Latitude = 0,
                Temperature = temperature,
                Stock = 0,
                Name = "Test",
                Time = DateTime.Now,
                UpdateType = "trade"
            };

            Assert.IsNotNull(mine.Temperature);
        }

        [Test]
        public void Stock_Zero_isValid()
        {
            var mine = new MineDbModel
            {
                Id = 1,
                Longitude = 0,
                Latitude = 0,
                Temperature = 10,
                Stock = 0,
                Name = "Test",
                Time = DateTime.Now,
                UpdateType = "trade"
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
                Id = 1,
                Longitude = 0,
                Latitude = 0,
                Temperature = 10,
                Stock = -1,
                Name = "Test",
                Time = DateTime.Now,
                UpdateType = "trade"
            };

            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(mine, new ValidationContext(mine), validationResults, true);

            Assert.False(isValid);
        }

        [TestCase(null)]
        public void Time_CannotBeNull(DateTime time)
        {
            var mine = new MineDbModel
            {
                Id = 1,
                Longitude = 0,
                Latitude = 0,
                Temperature = 0,
                Stock = 0,
                Name = "Test",
                Time =time,
                UpdateType = "trade"
            };

            Assert.IsNotNull(mine.Temperature);
        }

        [TestCase(null)]
        public void UpdateType_CanBeNull(string type)
        {
            var mine = new MineDbModel
            {
                Id = 1,
                Longitude = 0,
                Latitude = 0,
                Temperature = 0,
                Stock = 0,
                Name = "Test",
                Time = DateTime.Now,
                UpdateType = type
            };

            Assert.IsNull(mine.UpdateType);
        }
    }
}