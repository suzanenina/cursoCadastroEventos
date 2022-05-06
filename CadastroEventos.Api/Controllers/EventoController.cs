using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroEventos.Domain;
using CadastroEventos.Persistence;
using CadastroEventos.Persistence.Contextos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CadastroEventos.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly EventoContext _context;
       
        public EventoController(EventoContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("consultar")]
        public IEnumerable<Evento> Get()
        {
            return _context.Eventos;
        }
    }
}
