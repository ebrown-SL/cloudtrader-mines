using System.Threading.Tasks;

namespace CloudTrader.Mines.Service
{
    public interface IMineRepository
    {
        Task SaveMine(Mine mine);

        Task<Mine> GetMine(int id);
    }
}
