using System.Linq;
using System.Threading.Tasks;
using CadastroEventos.Domain;
using CadastroEventos.Persistence.Contextos;
using CadastroEventos.Persistence.Contrato;
using Microsoft.EntityFrameworkCore;

namespace CadastroEventos.Persistence
{
    public class EventoPersist : IEventoPersist
    {
        private EventoContext _context;

        public EventoPersist(EventoContext context)
        {
            _context = context;
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
            .Include(e => e.Lotes)
            .Include(e => e.RedeSociais);

            if(includePalestrantes)
            {
                query = query
                .Include(e => e.PalestrantesEventos)
                .ThenInclude(pe => pe.Palestrante);

            }
              
            query.OrderBy(e => e.EventoId);

            return await query.ToArrayAsync();
        }

        public async Task<Evento> GetEventoByIdAsync(int EventoId, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos.AsNoTracking()
            .Include(e => e.Lotes)
            .Include(e => e.RedeSociais);

            if(includePalestrantes)
            {
                 query = query
                .Include(e => e.PalestrantesEventos)
                .ThenInclude(pe => pe.Palestrante);
            }
              
            return await query.FirstOrDefaultAsync(e => e.EventoId.Equals(EventoId));
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
            .Where(e => e.Tema.ToLower().Contains(tema.ToLower()))
            .Include(e => e.Lotes)
            .Include(e => e.RedeSociais);

            if(includePalestrantes)
            {
                 query = query
                .Include(e => e.PalestrantesEventos)
                .ThenInclude(pe => pe.Palestrante);
            }
              
            query.OrderBy(e => e.EventoId);
            return await query.ToArrayAsync();
        }

    }
}