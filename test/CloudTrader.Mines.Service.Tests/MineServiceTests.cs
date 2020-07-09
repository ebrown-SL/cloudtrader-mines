using NUnit.Framework;
using Moq;
using CloudTrader.Mines.Service.Exceptions;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CloudTrader.Mines.Models.Data;
using CloudTrader.Mines.Models.Service;

namespace CloudTrader.Mines.Service.Tests
{
    public class MineServiceTests
    {
        private readonly MineProfile profile = new MineProfile();
        private readonly GeographicCoordinates coords = new GeographicCoordinates(0, 0);

        [Test]
        public async Task CreateMine_WithValidId_ReturnsValidMineAsync()
        {
            var mockMineRepository = new Mock<IMineRepository>();
            var config = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            var mapper = new Mapper(config);
            var mineService = new MineService(mockMineRepository.Object, mapper);

            mockMineRepository.Setup(mock => mock.GetMine(It.IsAny<int>())).ReturnsAsync((MineDbModel)null);
            mockMineRepository.Setup(mock => mock.SaveMine(It.IsAny<MineDbModel>())).ReturnsAsync(new MineDbModel() { Id = 1, Latitude = 0, Longitude = 0, Stock = 0, Temperature = 0 });

            var mine = await mineService.CreateMine(coords);

            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(mine, new System.ComponentModel.DataAnnotations.ValidationContext(mine), validationResults, true);

            Assert.True(isValid);
        }

        [Test]
        public async Task CreateMine_MineCreatedInDatabase_ReturnsCorrectMineId()
        {
            var mockMineRepository = new Mock<IMineRepository>();
            var config = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            var mapper = new Mapper(config);
            var mineService = new MineService(mockMineRepository.Object, mapper);

            mockMineRepository.Setup(mock => mock.GetMine(It.IsAny<int>())).ReturnsAsync((MineDbModel)null);
            mockMineRepository.Setup(mock => mock.SaveMine(It.IsAny<MineDbModel>())).ReturnsAsync(new MineDbModel() { Id = 1 });


            var mine = await mineService.CreateMine(coords);

            Assert.AreEqual(1, mine.Id);
        }

        [Test]
        public void GetMine_WithMineNotFound_ReturnsMineNotFoundException()
        {
            var mockMineRepository = new Mock<IMineRepository>();
            var config = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            var mapper = new Mapper(config);
            var mineService = new MineService(mockMineRepository.Object, mapper);

            mockMineRepository.Setup(mock => mock.GetMine(It.IsAny<int>())).ReturnsAsync((MineDbModel)null);

            Assert.ThrowsAsync<MineNotFoundException>(async () => await mineService.GetMine(1));
        }

        [Test]
        public async Task GetMine_WithMineFound_ReturnsMine()
        {
            var mockMineRepository = new Mock<IMineRepository>();
            var config = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            var mapper = new Mapper(config);
            var mineService = new MineService(mockMineRepository.Object, mapper);

            mockMineRepository.Setup(mock => mock.GetMine(It.IsAny<int>())).ReturnsAsync(new MineDbModel { Id = 1 });

            var mine = await mineService.GetMine(1);

            Assert.AreEqual(1, mine.Id);
        }
    }
}