using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CadastroEventos.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
       
        public EventoController()
        {

        }

        [HttpGet]
        [Route("consultar")]
        public string GetEventos()
        {
            return "teste api evento";
        }
    }
}
