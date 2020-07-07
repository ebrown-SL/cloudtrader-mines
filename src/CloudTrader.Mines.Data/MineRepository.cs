using CloudTrader.Mines.Models.Data;
using CloudTrader.Mines.Service;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Mine>> GetMines()
        {
            var mineDbModels = await _context.Mines.ToListAsync();
            var mines = _mapper.Map<List<Mine>>(mineDbModels);
            return mines;
        }

        public async Task SaveMine(Mine mine)
        {
            _context.Mines.Add(mine);
            await _context.SaveChangesAsync();
            return mine;
        }
    }
}
