using CloudTrader.Mines.Models.Data;
using CloudTrader.Mines.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CloudTrader.Mines.Data
{
    public class MineRepository : IMineRepository
    {
        private readonly MineContext _context;

        public MineRepository(MineContext context)
        {
            _context = context;
        }

        public async Task<MineDbModel> GetMine(int id)
        {
            var mine = await _context.Mines.FindAsync(id);
            return mine;
        }

        public async Task<List<MineDbModel>> GetMines()
        {
            var mines = await _context.Mines.ToListAsync();
            return mines;
        }

        public async Task<MineDbModel> SaveMine(MineDbModel mine)
        {
            _context.Mines.Add(mine);
            await _context.SaveChangesAsync();
            return mine;
        }

        public async Task<MineDbModel> UpdateMine(MineDbModel mine)
        {
            var mineToUpdate = await _context.Mines.FindAsync(mine.Id);
            if (mineToUpdate == null)
            {
                return null;
            }
            mineToUpdate.Latitude = mine.Latitude.HasValue ? mine.Latitude : mineToUpdate.Latitude;
            mineToUpdate.Longitude = mine.Longitude.HasValue ? mine.Latitude : mineToUpdate.Latitude;
            mineToUpdate.Name = String.IsNullOrWhiteSpace(mine.Name) ? mine.Name : mineToUpdate.Name;
            mineToUpdate.Stock = mine.Stock.HasValue ? mine.Stock : mineToUpdate.Stock;
            mineToUpdate.Temperature = mine.Temperature.HasValue ? mine.Temperature : mineToUpdate.Temperature;
            await _context.SaveChangesAsync();
            return mineToUpdate;
        }
    }
}
