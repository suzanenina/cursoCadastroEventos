using System.Threading.Tasks;
using CadastroEventos.Application.Dtos;
using CadastroEventos.Domain;

namespace CadastroEventos.Application.Contratos
{
    public interface IPalestranteService
    {
        Task<PalestranteDto[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos);
        Task<PalestranteDto[]> GetAllPalestrantesAsync(bool includeEventos);
        Task<PalestranteDto> GetPalestranteByIdAsync(int PalestranteId, bool includeEventos);
    }
}