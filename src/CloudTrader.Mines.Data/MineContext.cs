using CloudTrader.Mines.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace CloudTrader.Mines.Data
{
    public class MineContext : DbContext
    {
        public MineContext(DbContextOptions<MineContext> options) : base (options) { }

        public DbSet<MineDbModel> Mines { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "Mines");
        }
    }
}
