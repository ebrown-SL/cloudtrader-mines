using CloudTrader.Mines.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CloudTrader.Mines.Data
{
    public class MineContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public MineContext(DbContextOptions<MineContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<MineDbModel> Mines { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseCosmos(
                _configuration["CosmosEndpoint"],
                _configuration["CosmosKey"],
                databaseName: "CloudTrader");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultContainer("Mines");
            modelBuilder.Entity<MineDbModel>().HasData(
                new MineDbModel { Id = 1, Latitude = 17.38272783, Longitude = 98.27772635, Name = "Bristol", Stock = 3234, Temperature = 21 },
                new MineDbModel { Id = 2, Latitude = -55.2819173, Longitude = 132.27263546, Name = "York", Stock = 142, Temperature = 19 },
                new MineDbModel { Id = 3, Latitude = 8.28473625, Longitude = -1.37261536, Name = "Newcastle", Stock = 533, Temperature = 17 },
                new MineDbModel { Id = 4, Latitude = 62.29383399, Longitude = -35.38271662, Name = "London", Stock = 1346, Temperature = 22 }
            );
        }
    }
}
