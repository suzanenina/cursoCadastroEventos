using System.Linq;
using System.Threading.Tasks;
using CadastroEventos.Domain;
using CadastroEventos.Persistence.Contextos;
using CadastroEventos.Persistence.Contrato;
using Microsoft.EntityFrameworkCore;

namespace CadastroEventos.Persistence
{
    public class GeralPersist : IGeralPersist
    {
        private EventoContext _context;

        public GeralPersist(EventoContext context)
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
    }
}