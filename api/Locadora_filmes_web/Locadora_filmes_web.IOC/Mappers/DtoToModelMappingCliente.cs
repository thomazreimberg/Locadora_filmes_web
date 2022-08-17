using AutoMapper;
using Locadora_filmes_web.Data.Entity;
using Locadora_filmes_web.Dtos.Cliente;
using Locadora_filmes_web.Service.Interfaces.Entity;

namespace Locadora_filmes_web.IOC.Mappers
{
    public class DtoToModelMappingCliente : Profile
    {
        public DtoToModelMappingCliente()
        {
            Map();
        }

        private void Map()
        {
            CreateMap<ClienteDto, ICliente>()
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(x => x.Nome))
                .ForMember(dest => dest.Cpf, opt => opt.MapFrom(x => x.Cpf))
                .ForMember(dest => dest.DataNascimento, opt => opt.MapFrom(x => x.DataNascimento));

            CreateMap<ICliente, ClienteDto>()
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(x => x.Nome))
                .ForMember(dest => dest.Cpf, opt => opt.MapFrom(x => x.Cpf))
                .ForMember(dest => dest.DataNascimento, opt => opt.MapFrom(x => x.DataNascimento));

            CreateMap<ICliente, ClienteDtoConsulta>()
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(x => x.Nome))
                .ForMember(dest => dest.Cpf, opt => opt.MapFrom(x => x.Cpf))
                .ForMember(dest => dest.DataNascimento, opt => opt.MapFrom(x => x.DataNascimento));

            CreateMap<ICliente, Cliente>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(x => x.Nome))
                .ForMember(dest => dest.Cpf, opt => opt.MapFrom(x => x.Cpf))
                .ForMember(dest => dest.DataNascimento, opt => opt.MapFrom(x => x.DataNascimento));
        }
    }
}
