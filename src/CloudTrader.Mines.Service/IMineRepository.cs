using CloudTrader.Mines.Models.Data;
using System.Threading.Tasks;

namespace CloudTrader.Mines.Service
{
    public interface IMineRepository
    {
        Task<MineDbModel> SaveMine(MineDbModel mine);

        Task<MineDbModel> GetMine(int id);
    }
}
