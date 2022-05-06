using System;
using System.Threading.Tasks;
using CadastroEventos.Domain;
using CadastroEventos.Persistence.Contrato;

namespace CadastroEventos.Application.Contratos
{
    public class EventoService : IEventoService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IEventoPersist _eventoPersist;

        public async Task<Evento> AddEvento(Evento model)
        {
            try
            {
                _geralPersist.Add<Evento>(model);

                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _eventoPersist.GetEventoByIdAsync(model.EventoId, false);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public async Task<Evento> UpdateEvento(int eventoId, Evento model)
        {
            try
            {
                var evento = await _eventoPersist.GetEventoByIdAsync(eventoId, false);

                if(evento == null) return null;

                _geralPersist.Update(model);
                
                if(await _geralPersist.SaveChangesAsync())
                {
                    return await _eventoPersist.GetEventoByIdAsync(eventoId, false);
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

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersist.GetAllEventosAsync(includePalestrantes);

                if(eventos == null) return null;

                return eventos;
            }
            catch (System.Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> GetAllEventosByIdAsync(int EventoId, bool includePalestrantes = false)
        {
             try
            {
                var eventos = await _eventoPersist.GetEventoByIdAsync(EventoId, includePalestrantes);

                if(eventos == null) return null;

                return eventos;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
             try
            {
                var eventos = await _eventoPersist.GetAllEventosByTemaAsync(tema, includePalestrantes);

                if(eventos == null) return null;

                return eventos;
            }
            catch (System.Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }


    }
}