using AutoMapper;
using Concessionaria.Models;
using Concessionaria.Models.DTOs;

namespace Concessionaria.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UsuarioCadastroDto, Usuario>()
                .ForMember(dest => dest.Id, 
                    opt => opt.Ignore())
                .ForMember(dest => dest.NomeCompleto,
                    opt => opt.Ignore());

            CreateMap<MarcaDto, Marca>()
                .ForMember(dest => dest.MarcaId, opt => opt.Ignore());

            CreateMap<CarroDto, Carro>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Marca, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
