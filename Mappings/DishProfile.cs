using AutoMapper;
using OrderKaBA.DTOs;
using OrderKaBA.Models;

namespace OrderKaBA.Mappings
{
    public class DishProfile : Profile
    {
        public DishProfile()
        {
            CreateMap<Dish, DishReadDto>();
            CreateMap<DishCreateDto, Dish>();
            CreateMap <DishUpdateDto, Dish>();
        }
    }
}
