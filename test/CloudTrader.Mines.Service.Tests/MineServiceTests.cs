using NUnit.Framework;
using Moq;
using CloudTrader.Mines.Service.Exceptions;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CloudTrader.Mines.Service.Tests
{
    public class MineServiceTests
    {
        [Test]
        public void CreateMine_WithMineIdAlreadyExists_ThrowsMineAlreadyExistsExeption()
        {
            var mockMineRepository = new Mock<IMineRepository>();
            var mineService = new MineService(mockMineRepository.Object);

            mockMineRepository.Setup(mock => mock.GetMine(It.IsAny<int>())).ReturnsAsync(new Mine());

            Assert.ThrowsAsync<MineAlreadyExistsException>(async () => await mineService.CreateMine(1, 0, 0));
        }

        [Test]
        public async Task CreateMine_WithValidId_ReturnsValidMineAsync()
        {
            var mockMineRepository = new Mock<IMineRepository>();
            var mineService = new MineService(mockMineRepository.Object);

            mockMineRepository.Setup(mock => mock.GetMine(It.IsAny<int>())).ReturnsAsync((Mine) null);

            var mine = await mineService.CreateMine(1, 0, 0);

            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(mine, new ValidationContext(mine), validationResults, true);

            Assert.True(isValid);
        }

        [Test]
        public async Task CreateMine_WithValidId_ReturnsCorrectMineId()
        {
            var mockMineRepository = new Mock<IMineRepository>();
            var mineService = new MineService(mockMineRepository.Object);

            mockMineRepository.Setup(mock => mock.GetMine(It.IsAny<int>())).ReturnsAsync((Mine) null);

            var mine = await mineService.CreateMine(1, 0, 0);

            Assert.AreEqual(1, mine.Id);
        }

        [Test]
        public void GetMine_WithMineNotFound_ReturnsMineNotFoundException()
        {
            var mockMineRepository = new Mock<IMineRepository>();
            var mineService = new MineService(mockMineRepository.Object);

            mockMineRepository.Setup(mock => mock.GetMine(It.IsAny<int>())).ReturnsAsync((Mine) null);

            Assert.ThrowsAsync<MineNotFoundException>(async () => await mineService.GetMine(1));
        }

        [Test]
        public async Task GetMine_WithMineFound_ReturnsMine()
        {
            var mockMineRepository = new Mock<IMineRepository>();
            var mineService = new MineService(mockMineRepository.Object);

            mockMineRepository.Setup(mock => mock.GetMine(It.IsAny<int>())).ReturnsAsync(new Mine { Id = 1 });

            var mine = await mineService.GetMine(1);

            Assert.AreEqual(1, mine.Id);
        }
    }
}