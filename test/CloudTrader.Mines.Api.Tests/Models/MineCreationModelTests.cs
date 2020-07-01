using CloudTrader.Mines.Api.Models;
using NUnit.Framework;

namespace CloudTrader.Mines.Api.Tests.Models
{
    public class MineCreationModelTests
    {
        [TestCase(null)]
        public void MineCreationModel_Id_CannotBeNull(int id)
        {
            var mine = new MineCreationModel
            {
                Id = id,
                Longitude = 0,
                Latitude = 0
            };

            Assert.IsNotNull(mine.Id);
        }
    }
}
