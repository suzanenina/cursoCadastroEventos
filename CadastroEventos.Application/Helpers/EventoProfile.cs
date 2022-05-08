using AutoMapper;
using CadastroEventos.Application.Dtos;
using CadastroEventos.Domain;

namespace CadastroEventos.Api.Helpers
{
    public class EventoProfile : Profile
    {
        public EventoProfile()
        {
            CreateMap<Evento, EventoDto>().ReverseMap();
   

        }
    }
}