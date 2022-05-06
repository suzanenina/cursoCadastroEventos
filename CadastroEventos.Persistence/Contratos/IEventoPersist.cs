using System.Threading.Tasks;
using CadastroEventos.Domain;

namespace CadastroEventos.Persistence.Contrato
{
    public interface IEventoPersist
    {
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes);
        Task<Evento[]> GetAllEventosAsync(bool includePalestrantes);
        Task<Evento> GetEventoByIdAsync(int EventoId, bool includePalestrantes);
    }
}