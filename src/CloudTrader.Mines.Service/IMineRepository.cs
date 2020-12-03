using CloudTrader.Mines.Models.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CloudTrader.Mines.Service
{
    public interface IMineRepository
    {
        Task<MineDbModel> SaveMine(MineDbModel mine);

        Task<MineDbModel> GetMine(Guid id);

        Task<List<MineDbModel>> GetMines();

        Task<MineDbModel> UpdateMine(MineDbModel mine);
    }
}