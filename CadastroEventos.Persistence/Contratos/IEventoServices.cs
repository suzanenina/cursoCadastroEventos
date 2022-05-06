using System.Threading.Tasks;
using CadastroEventos.Domain;

namespace CadastroEventos.Persistence.Contrato
{
    public interface IEventoService
    {
        Task<Evento> AddEvento(Evento model);
        Task<Evento> UpdateEvento(int eventoId, Evento model);
        Task<bool> DeleteEvento(int eventoId);


        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes= false);
        Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false);
        Task<Evento> GetAllEventosByIdAsync(int EventoId, bool includePalestrantes = false);
    }
}