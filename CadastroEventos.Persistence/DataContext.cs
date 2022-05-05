
using CadastroEventos.Domain;
using Microsoft.EntityFrameworkCore;

namespace CadastroEventos.Api.Data
{

    public class EventoContext : DbContext
    {
       public EventoContext(DbContextOptions<EventoContext> options ) : base (options) {}

       DbSet<Evento> Eventos {get;set;}


    }

}