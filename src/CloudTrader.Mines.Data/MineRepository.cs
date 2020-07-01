using AutoMapper;
using CloudTrader.Mines.Service;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CloudTrader.Mines.Data
{
    public class MineRepository : IMineRepository
    {
        private readonly MineContext _context;

        private readonly IMapper _mapper;

        public MineRepository(IMapper mapper)
        {
            _mapper = mapper;

            var contextOptions = new DbContextOptionsBuilder<MineContext>()
                .UseInMemoryDatabase(databaseName: "Mines")
                .Options;
            _context = new MineContext(contextOptions);
        }

        public async Task<Mine> GetMine(int id)
        {
            var mineDbModel = await _context.Mines.FindAsync(id);
            var mine = _mapper.Map<Mine>(mineDbModel);
            return mine;
        }

        public async Task SaveMine(Mine mine)
        {
            var mineDbModel = _mapper.Map<MineDbModel>(mine);
            _context.Mines.Add(mineDbModel);
            await _context.SaveChangesAsync();
        }
    }
}
