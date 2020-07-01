using CloudTrader.Mines.Service.Exceptions;
using System.Threading.Tasks;

namespace CloudTrader.Mines.Service
{
    public interface IMineService
    {
        Task<Mine> CreateMine(int id, double latitude, double longitude);
        Task<Mine> GetMine(int id);
    }
    public class MineService : IMineService
    {
        private readonly IMineRepository _mineRepository;

        public MineService(IMineRepository mineRepository)
        {
            _mineRepository = mineRepository;
        }

        public async Task<Mine> CreateMine(int id, double latitude, double longitude)
        {
            var existingMine = await _mineRepository.GetMine(id);
            if (existingMine != null)
            {
                throw new MineAlreadyExistsException(id);
            }

            var mine = new Mine
            {
                Id = id,
                Longitude = longitude,
                Latitude = latitude
            };
            await _mineRepository.SaveMine(mine);

            return mine;
        }

        public async Task<Mine> GetMine(int id)
        {
            var mine = await _mineRepository.GetMine(id);
            if (mine == null)
            {
                throw new MineNotFoundException(id);
            }

            return mine;
        }
    }
}
