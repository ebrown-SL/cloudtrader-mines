using AutoMapper;
using CloudTrader.Mines.Service;

namespace CloudTrader.Mines.Data
{
    public class MineProfile : Profile
    {
        public MineProfile()
        {
            CreateMap<Mine, MineDbModel>()
                .ReverseMap();
        }
    }
}
