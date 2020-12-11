using AutoMapper;
using CloudTrader.Mines.Models.Data;
using CloudTrader.Mines.Models.Service;
using CloudTrader.Mines.Service.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudTrader.Mines.Service
{
    public interface IMineService
    {
        Task<Mine> CreateMine(string name, GeographicCoordinates coordinates);

        Task<Mine> GetMine(Guid id);

        Task<List<Mine>> GetMines();

        Task<Mine> UpdateMine(Guid id, MineUpdateModel updatedMine);
    }

    public class MineService : IMineService
    {
        private readonly IMineRepository _mineRepository;

        private readonly IMapper _mapper;

        public MineService(IMineRepository mineRepository, IMapper mapper)
        {
            _mineRepository = mineRepository;

            _mapper = mapper;
        }

        public async Task<Mine> CreateMine(string name, GeographicCoordinates coordinates)
        {
            var mineDbModel = new MineDbModel { Name = name, Latitude = coordinates.Latitude, Longitude = coordinates.Longitude };

            var savedMine = await _mineRepository.SaveMine(mineDbModel);

            return _mapper.Map<Mine>(savedMine); ;
        }

        public async Task<Mine> GetMine(Guid id)
        {
            var mineDbModel = await _mineRepository.GetMine(id);
            if (mineDbModel == null)
            {
                throw new MineNotFoundException(id);
            }

            return _mapper.Map<Mine>(mineDbModel);
        }

        public async Task<List<Mine>> GetMines()
        {
            var mines = await _mineRepository.GetMines();
            return _mapper.Map<List<Mine>>(mines);
        }

        public async Task<Mine> UpdateMine(Guid id, MineUpdateModel updateMine)
        {
            var mineDbModel = _mapper.Map<MineDbModel>(updateMine);
            mineDbModel.Id = id;
            var mine = await _mineRepository.UpdateMine(mineDbModel);
            if (mine == null)
            {
                throw new MineNotFoundException(id);
            }
            return _mapper.Map<Mine>(mine);
        }
    }
}