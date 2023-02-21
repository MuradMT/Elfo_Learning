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
        }
    }
}
