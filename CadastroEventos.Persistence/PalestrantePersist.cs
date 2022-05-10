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
            .Include(p => p.RedesSociais);

            if(includeEventos)
            {
                query = query
                .Include(p => p.PalestrantesEventos)
                .ThenInclude(pp => pp.Evento);

            }
              
            query.OrderBy(p => p.PalestranteId);

            return await query.ToArrayAsync();

        }

        public async Task<Palestrante> GetPalestranteByIdAsync(int PalestranteId, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes.AsNoTracking()
            .Include(p => p.RedesSociais);

            if(includeEventos)
            {
                 query = query
                .Include(p => p.PalestrantesEventos)
                .ThenInclude(pp => pp.Evento);
            }
              
            return await query.FirstOrDefaultAsync(p => p.PalestranteId.Equals(PalestranteId));
        }

        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes.AsNoTracking()
            .Where(p =>  p.User.PrimeiroNome.ToLower().Contains(nome.ToLower()))
            .Include(p => p.RedesSociais);

            if(includeEventos)
            {
                 query = query
                .Include(p => p.PalestrantesEventos)
                .ThenInclude(pp => pp.Evento);
            }
              
            query.OrderBy(p => p.PalestranteId);
            return await query.ToArrayAsync();
        }


    }
}