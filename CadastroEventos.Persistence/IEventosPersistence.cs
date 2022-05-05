using System.Threading.Tasks;
using CadastroEventos.Domain;

namespace CadastroEventos.Persistence
{
    public interface IEventosPersistence
    {
        #region Geral
        void Add<T>(T entity) where T: class;
        void Update<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        void DeleteRange<T>(T[] entity) where T: class;

        Task<bool> SaveChangesAsync();

        #endregion


        #region Eventos

        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes);
        Task<Evento[]> GetAllEventosAsync(bool includePalestrantes);
        Task<Evento> GetAllEventosByIdAsync(int EventoId, bool includePalestrantes);

        #endregion

        #region Palestrantes

        Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string tema, bool includeEventos);
        Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos);
        Task<Palestrante> GetAllPalestrantesByIdAsync(int PalestranteId, bool includeEventos);

        #endregion


    }
}