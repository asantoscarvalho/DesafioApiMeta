using AutoMapper;
using Contatos.api.Dto;
using Contatos.Domain;

namespace Contatos.api.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Contato, ContatoDto>().ReverseMap();
        }
        
    }
}