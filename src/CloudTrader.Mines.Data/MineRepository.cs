using CloudTrader.Mines.Models.Data;
using CloudTrader.Mines.Service;
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

        public async Task<MineDbModel> SaveMine(MineDbModel mine)
        {
            _context.Mines.Add(mine);
            await _context.SaveChangesAsync();
            return mine;
        }
    }
}
