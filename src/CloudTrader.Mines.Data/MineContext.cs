using Microsoft.EntityFrameworkCore;

namespace CloudTrader.Mines.Data
{
    public class MineContext : DbContext
    {
        public MineContext(DbContextOptions<MineContext> options) : base (options) { }

        public DbSet<MineDbModel> Mines { get; set; }
    }
}
