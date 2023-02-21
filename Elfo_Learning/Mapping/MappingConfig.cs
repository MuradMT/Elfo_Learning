using AutoMapper;
using Elfo_Learning.Entities;
using Elfo_Learning.Models;

namespace Elfo_Learning.Mapping
{
    public class MappingConfig:Profile
    {
        public MappingConfig()
        {
            CreateMap<City,CityDto>().ReverseMap();
            CreateMap<City,CityCreateDto>().ReverseMap();
            CreateMap<City, CityUpdateDto>().ReverseMap();
        }
    }
}
