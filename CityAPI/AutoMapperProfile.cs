using AutoMapper;
using CityAPI.Core;
using CityAPI.Core.Dtos.City;

namespace CityAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<CityEntity, GetCity>();
            CreateMap<AddCity, CityEntity>();


        }
    }
}
