using AutoMapper;
using CloudTrader.Mines.Models.Data;
using CloudTrader.Mines.Models.Service;
using CloudTrader.Mines.Service.Exceptions;
﻿using CloudTrader.Mines.Service.Exceptions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CloudTrader.Mines.Service
{
    public interface IMineService
    {
        Task<Mine> CreateMine(GeographicCoordinates coordinates);
        Task<Mine> GetMine(int id);
        Task<List<Mine>> GetMines();
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

        public async Task<Mine> CreateMine(GeographicCoordinates coordinates)
        {
            var mineDbModel = new MineDbModel { Latitude = coordinates.Latitude, Longitude = coordinates.Longitude };

            var savedMine = await _mineRepository.SaveMine(mineDbModel);

            return _mapper.Map<Mine>(savedMine); ;

        }

        public async Task<Mine> GetMine(int id)
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
            return mines;
        }
    }
}
