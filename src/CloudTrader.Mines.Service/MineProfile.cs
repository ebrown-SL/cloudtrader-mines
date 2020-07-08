using AutoMapper;
using CloudTrader.Mines.Models.Data;
using CloudTrader.Mines.Models.Service;

namespace CloudTrader.Mines.Service
{
    public class MineProfile : Profile
    {
        public MineProfile()
        {
            CreateMap<Mine, MineDbModel>()
                .ForMember(dest => dest.Latitude, act => act.MapFrom(src => src.Coordinates.Latitude))
                .ForMember(dest => dest.Longitude, act => act.MapFrom(src => src.Coordinates.Longitude))
                .ReverseMap();
        }
    }
}
