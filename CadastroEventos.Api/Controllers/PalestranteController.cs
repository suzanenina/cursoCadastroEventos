using System.Threading.Tasks;
using CadastroEventos.Application.Contratos;
using CadastroEventos.Application.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CadastroPalestrantes.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PalestranteController : ControllerBase
    {
        private readonly IPalestranteService _PalestranteService;
       
        public PalestranteController(IPalestranteService PalestranteService)
        {
            _PalestranteService = PalestranteService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> Get()
        {
            try
            {
                 var Palestrantes = await _PalestranteService.GetAllPalestrantesAsync(false);
                 if(Palestrantes == null) return NoContent();

                 return Ok(Palestrantes);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                 $"Erro ao tentar recuperar Palestrantes. Erro: {ex.Message}"); 
                throw;
            }
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                 var Palestrante = await _PalestranteService.GetPalestranteByIdAsync(id, false);
                 if(Palestrante == null) return NoContent();

                 return Ok(Palestrante);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                 $"Erro ao tentar recuperar Palestrantes. Erro: {ex.Message}"); 
                throw;
            }
        }

        [HttpGet("nome/{nome}")]
        public async Task<IActionResult> GetByNome(string nome)
        {
            try
            {
                 var Palestrantes = await _PalestranteService.GetAllPalestrantesByNomeAsync(nome, false);
                 if(Palestrantes == null) return NoContent();

                 return Ok(Palestrantes);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                 $"Erro ao tentar recuperar Palestrantes. Erro: {ex.Message}"); 
                throw;
            }
        }

       
        
    }
}
