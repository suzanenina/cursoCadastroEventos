using System.Linq;
using System.Threading.Tasks;
using CadastroEventos.Domain;
using Microsoft.EntityFrameworkCore;

namespace CadastroEventos.Persistence
{
    public class EventosPersistence : IEventosPersistence
    {
        private EventoContext _context;

        public EventosPersistence(EventoContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entity) where T : class
        {
            _context.RemoveRange(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
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

        public async Task<Evento> GetAllEventosByIdAsync(int EventoId, bool includePalestrantes = false)
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

        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false)
        {
             IQueryable<Palestrante> query = _context.Palestrantes
            .Include(e => e.RedesSociais);

            if(includeEventos)
            {
                query = query
                .Include(e => e.PalestrantesEventos)
                .ThenInclude(pe => pe.Evento);

            }
              
            query.OrderBy(e => e.Id);

            return await query.ToArrayAsync();

        }

        public async Task<Palestrante> GetAllPalestrantesByIdAsync(int PalestranteId, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
            .Include(e => e.RedesSociais);

            if(includeEventos)
            {
                 query = query
                .Include(e => e.PalestrantesEventos)
                .ThenInclude(pe => pe.Evento);
            }
              
            return await query.FirstOrDefaultAsync(e => e.Id.Equals(PalestranteId));
        }

        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
            .Where(e => e.Nome.ToLower().Contains(nome.ToLower()))
            .Include(e => e.RedesSociais);

            if(includeEventos)
            {
                 query = query
                .Include(e => e.PalestrantesEventos)
                .ThenInclude(pe => pe.Evento);
            }
              
            query.OrderBy(e => e.Id);
            return await query.ToArrayAsync();
        }


    }
}