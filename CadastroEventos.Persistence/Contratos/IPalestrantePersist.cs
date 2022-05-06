using System.Threading.Tasks;
using CadastroEventos.Domain;

namespace CadastroEventos.Persistence.Contrato
{

    public interface IPalestrantePersist
    {
        Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string tema, bool includeEventos);
        Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos);
        Task<Palestrante> GetAllPalestrantesByIdAsync(int PalestranteId, bool includeEventos);
    }
}