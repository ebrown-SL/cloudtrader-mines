using CloudTrader.Mines.Models.Data;
using CloudTrader.Mines.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace CloudTrader.Mines.Data
{
    public class MineRepository : IMineRepository
    {
        private readonly MineContext _context;

        public MineRepository(MineContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        public async Task<MineDbModel> GetMine(Guid id)
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
            foreach (PropertyInfo prop in mine.GetType().GetProperties())
            {
                if (prop.GetValue(mine) != null)
                {
                    mineToUpdate
                        .GetType()
                        .GetProperty(prop.Name)
                        .SetValue(mineToUpdate, prop.GetValue(mine));
                }
            }
            await _context.SaveChangesAsync();
            return mineToUpdate;
        }
    }
}