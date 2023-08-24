using AutoMapper;
using CadastroClienteXpTeste.API.DTOs;
using CadastroClienteXpTeste.API.Core.Entities;


namespace CadastroClienteXpTeste.API.Infrastructure.AutoMapper
{
    public class ClienteMap : Profile
    {
        public ClienteMap()
        {
            CreateMap<EntityBase, EntityBaseDTO>()
         .ReverseMap();

            CreateMap<Cliente, ClienteDTO>()
         .ReverseMap();

            CreateMap<Email, EmailDTO>()
         .ReverseMap();

            CreateMap<Endereco, EnderecoDTO>()
         .ReverseMap();

            CreateMap<Telefone, TelefoneDTO>()
         .ReverseMap();

        }
    }
}