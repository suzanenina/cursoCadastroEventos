using System.Linq;
using System.Threading.Tasks;
using CadastroEventos.Domain;
using CadastroEventos.Persistence.Contextos;
using CadastroEventos.Persistence.Contrato;
using Microsoft.EntityFrameworkCore;

namespace CadastroEventos.Persistence
{
    public class PalestrantePersist : IPalestrantePersist
    {
        private EventoContext _context;

        public PalestrantePersist(EventoContext context)
        {
            _context = context;
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