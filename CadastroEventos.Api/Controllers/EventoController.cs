using System.Threading.Tasks;
using CadastroEventos.Application.Contratos;
using CadastroEventos.Application.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CadastroEventos.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly IEventoService _eventoService;
       
        public EventoController(IEventoService eventoService)
        {
            _eventoService = eventoService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> Get()
        {
            try
            {
                 var eventos = await _eventoService.GetAllEventosAsync(false);
                 if(eventos == null) return NoContent();

                 return Ok(eventos);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                 $"Erro ao tentar recuperar eventos. Erro: {ex.Message}"); 
                throw;
            }
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                 var evento = await _eventoService.GetEventoByIdAsync(id);
                 if(evento == null) return NoContent();

                 return Ok(evento);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                 $"Erro ao tentar recuperar eventos. Erro: {ex.Message}"); 
                throw;
            }
        }

        [HttpGet("tema/{tema}")]
        public async Task<IActionResult> GetByTema(string tema)
        {
            try
            {
                 var eventos = await _eventoService.GetAllEventosByTemaAsync(tema);
                 if(eventos == null) return NoContent();

                 return Ok(eventos);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                 $"Erro ao tentar recuperar eventos. Erro: {ex.Message}"); 
                throw;
            }
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(EventoDto model)
        {
            try
            {
                 var evento = await _eventoService.AddEvento(model);
                 if(evento == null) return NoContent();

                 return Ok(evento);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                 $"Erro ao tentar recuperar eventos. Erro: {ex.Message}"); 
                throw;
            }
        }

        [HttpPut("put/{id}")]
        public async Task<IActionResult> Put(int id, EventoDto model)
        {
            try
            {
                 var evento = await _eventoService.UpdateEvento(id, model);
                 if(evento == null) return NoContent();

                 return Ok(evento);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                 $"Erro ao tentar recuperar eventos. Erro: {ex.Message}"); 
                throw;
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {                
                 if(!await _eventoService.DeleteEvento(id)) 
                    throw new System.Exception
                    ("Ocorreu um problema não específico ao tentar deletar Evento");
                               
                return Ok("Evento excluído com sucesso!");
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                 $"Erro ao tentar recuperar eventos. Erro: {ex.Message}"); 
                throw;
            }
        }
    }
}
