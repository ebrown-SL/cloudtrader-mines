using NUnit.Framework;
using Moq;
using FluentAssertions;
using CloudTrader.Mines.Service.Exceptions;
using System;
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

            mockMineRepository.Setup(mock => mock.GetMine(It.IsAny<Guid>())).ReturnsAsync((MineDbModel)null);
            mockMineRepository.Setup(mock => mock.SaveMine(It.IsAny<MineDbModel>())).ReturnsAsync(new MineDbModel() { Id = Guid.NewGuid(), Latitude = 0, Longitude = 0, Stock = 0, Temperature = 0, Name = "Test" });

            var mine = await mineService.CreateMine("Test", coords);

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

            Guid mineId = Guid.NewGuid();

            mockMineRepository.Setup(mock => mock.GetMine(It.IsAny<Guid>())).ReturnsAsync((MineDbModel)null);
            mockMineRepository.Setup(mock => mock.SaveMine(It.IsAny<MineDbModel>())).ReturnsAsync(new MineDbModel() { Id = mineId });

            var mine = await mineService.CreateMine("Test", coords);

            Assert.AreEqual(mineId, mine.Id);
        }

        [Test]
        public void GetMine_WithMineNotFound_ReturnsMineNotFoundException()
        {
            var mockMineRepository = new Mock<IMineRepository>();
            var config = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            var mapper = new Mapper(config);
            var mineService = new MineService(mockMineRepository.Object, mapper);

            mockMineRepository.Setup(mock => mock.GetMine(It.IsAny<Guid>())).ReturnsAsync((MineDbModel)null);

            Assert.ThrowsAsync<MineNotFoundException>(async () => await mineService.GetMine(Guid.NewGuid()));
        }

        [Test]
        public async Task GetMine_WithMineFound_ReturnsMine()
        {
            var mockMineRepository = new Mock<IMineRepository>();
            var config = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            var mapper = new Mapper(config);
            var mineService = new MineService(mockMineRepository.Object, mapper);

            Guid mineId = Guid.NewGuid();

            mockMineRepository.Setup(mock => mock.GetMine(It.IsAny<Guid>())).ReturnsAsync(new MineDbModel { Id = mineId });

            var mine = await mineService.GetMine(mineId);

            Assert.AreEqual(mineId, mine.Id);
        }

        [Test]
        public async Task GetMines_NoMines_ReturnsEmptyList()
        {
            var mockMineRepository = new Mock<IMineRepository>();
            var config = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            var mapper = new Mapper(config);
            var mineService = new MineService(mockMineRepository.Object, mapper);

            mockMineRepository.Setup(mock => mock.GetMines()).ReturnsAsync(new List<MineDbModel>());

            var mines = await mineService.GetMines();
            var isEmpty = mines.Count == 0;

            Assert.True(isEmpty);
        }

        [Test]
        public async Task GetMines_MinesFound_ReturnsListOfMines()
        {
            var mockMineRepository = new Mock<IMineRepository>();
            var config = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            var mapper = new Mapper(config);
            var mineService = new MineService(mockMineRepository.Object, mapper);

            mockMineRepository.Setup(mock => mock.GetMines()).ReturnsAsync(new List<MineDbModel>() {
                new MineDbModel(), new MineDbModel(), new MineDbModel() });

            var mines = await mineService.GetMines();
            var hasMines = mines.Count == 3;

            Assert.True(hasMines);
        }

        [Test]
        public void UpdateMine_IdNotFound_ReturnsMineNotFoundException()
        {
            var mockMineRepository = new Mock<IMineRepository>();
            var config = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            var mapper = new Mapper(config);
            var mineService = new MineService(mockMineRepository.Object, mapper);

            mockMineRepository.Setup(mock => mock.UpdateMine(It.Is<MineDbModel>(x => x.UpdateType == UpdateType.weather))).ReturnsAsync((MineDbModel)null);

            var mineUpdater = new MineUpdateModel { UpdateType = UpdateType.weather };

            Assert.ThrowsAsync<MineNotFoundException>(async () => await mineService.UpdateMine(1, mineUpdater));
        }

        [Test]
        public async Task UpdateMine_ValidId_ReturnsUpdatedMine()
        {
            var mockMineRepository = new Mock<IMineRepository>();
            var config = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            var mapper = new Mapper(config);
            var mineService = new MineService(mockMineRepository.Object, mapper);
            Guid expectedId = Guid.NewGuid();

            mockMineRepository
                .Setup(mock => mock.UpdateMine(It.IsAny<MineDbModel>()))
                .ReturnsAsync(new MineDbModel() { Id = expectedId, Latitude = 1, Longitude = 1, Name = "New", Stock = 1, Temperature = 1, UpdateType = UpdateType.weather });

            var expectedUpdatedMine = new Mine() { Id = expectedId, Coordinates = new GeographicCoordinates(1, 1), Name = "New", Stock = 1, Temperature = 1 };
            var actualUpdatedMine = await mineService
                .UpdateMine(expectedId, new MineUpdateModel() { Coordinates = new GeographicCoordinates(1, 1), Name = "New", Stock = 1, Temperature = 1, UpdateType = UpdateType.weather });  ;

            actualUpdatedMine.Should().BeEquivalentTo(expectedUpdatedMine);
        }
    }
}