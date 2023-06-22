using AutoMapper;
using Tescaro.GBT.API.DTOs;
using Tescaro.GBT.Appplication.DTOs;
using Tescaro.GBT.Domain.Identity;
using Tescaro.GBT.Domain.Models;

namespace Tescaro.GBT.API.Helpers
{
    public class GBTPMapper : Profile
    {
        public GBTPMapper() 
        {
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            CreateMap<DNS, DNSDTO>().ReverseMap();
            CreateMap<BancoDados, BancoDadosDTO>().ReverseMap();    
            CreateMap<Chamado, ChamadoDTO>().ReverseMap();
            
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, UserLoginDTO>().ReverseMap();
            CreateMap<User, UserUpdateDTO>().ReverseMap();
        }
    }
}
