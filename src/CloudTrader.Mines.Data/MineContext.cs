using CloudTrader.Mines.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace CloudTrader.Mines.Data
{
    public class MineContext : DbContext
    {
        public MineContext(DbContextOptions<MineContext> options) : base(options) { }

        public DbSet<MineDbModel> Mines { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "Mines");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MineDbModel>().HasData(
                new MineDbModel { Id = 1, Latitude = 17.38272783, Longitude = 98.27772635, Name = "Bristol", Stock = 3234, Temperature = 21 },
                new MineDbModel { Id = 2, Latitude = -55.2819173, Longitude = 132.27263546, Name = "York", Stock = 142, Temperature = 19 },
                new MineDbModel { Id = 3, Latitude = 8.28473625, Longitude = -1.37261536, Name = "Newcastle", Stock = 533, Temperature = 17 },
                new MineDbModel { Id = 4, Latitude = 62.29383399, Longitude = -35.38271662, Name = "London", Stock = 1346, Temperature = 22 }
            );
        }
    }
}
