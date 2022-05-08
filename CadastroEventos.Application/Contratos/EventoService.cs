using System;
using System.Threading.Tasks;
using AutoMapper;
using CadastroEventos.Application.Dtos;
using CadastroEventos.Domain;
using CadastroEventos.Persistence.Contrato;

namespace CadastroEventos.Application.Contratos
{
    public class EventoService : IEventoService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IEventoPersist _eventoPersist;

        private readonly IMapper _mapper;

        public EventoService(IGeralPersist geralPersist, IEventoPersist eventoPersist, IMapper mappper)
        {
            _eventoPersist = eventoPersist;
            _geralPersist = geralPersist;
            _mapper = mappper;
        }

        public async Task<EventoDto> AddEvento(EventoDto model)
        {
            try
            {
                var evento = _mapper.Map<Evento>(model);

                _geralPersist.Add<Evento>(evento);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var retorno = await _eventoPersist.GetEventoByIdAsync(evento.EventoId, false);
                    return _mapper.Map<EventoDto>(retorno);

                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public async Task<EventoDto> UpdateEvento(int eventoId, EventoDto model)
        {
            try
            {
                var evento = await _eventoPersist.GetEventoByIdAsync(eventoId, false);

                if(evento == null) return null;

                _mapper.Map(model, evento);

                _geralPersist.Update<Evento>(evento);
                
                if(await _geralPersist.SaveChangesAsync())
                {
                    var retornoEvento = await _eventoPersist.GetEventoByIdAsync(eventoId, false);
                    return _mapper.Map<EventoDto>(retornoEvento);
                }

                return null;
            }
            catch (System.Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEvento(int eventoId)
        {
            try
            {
                var evento = await _eventoPersist.GetEventoByIdAsync(eventoId, false);

                if(evento == null) 
                    throw new Exception("Evento para delete não encontrado.");

                _geralPersist.Delete<Evento>(evento);
                
               return await _geralPersist.SaveChangesAsync();

            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDto[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersist.GetAllEventosAsync(includePalestrantes);

                if(eventos == null) return null;

                var resultado = _mapper.Map<EventoDto[]>(eventos);

                return resultado;
            }
            catch (System.Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDto> GetEventoByIdAsync(int EventoId, bool includePalestrantes = false)
        {
             try
            {
                var evento = await _eventoPersist.GetEventoByIdAsync(EventoId, includePalestrantes);

                if(evento == null) return null;

                var resultado = _mapper.Map<EventoDto>(evento);

                return resultado;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDto[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
             try
            {
                var eventos = await _eventoPersist.GetAllEventosByTemaAsync(tema, includePalestrantes);

                if(eventos == null) return null;

                 var resultado = _mapper.Map<EventoDto[]>(eventos);

                return resultado;
            }
            catch (System.Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

    }
}