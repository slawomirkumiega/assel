using Assel.DTO;
using Assel.Entities;
using AutoMapper;

namespace Assel.Mappers
{
    internal sealed class AutoMapperFactProfile : Profile
    {
        public AutoMapperFactProfile()
        {
            CreateMap<Fact, FactDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))                
                .ForMember(dest => dest.FactText, opt => opt.MapFrom(src => src.FactText))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.PetType, opt => opt.MapFrom(src => src.PetType));
        }
    }
}
