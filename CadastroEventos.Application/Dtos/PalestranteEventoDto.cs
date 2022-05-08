namespace CadastroEventos.Application.Dtos
{
    public class PalestranteEventoDto
    {
        public int PalestranteId { get; set; }
        public int EventoId { get; set; }
        public PalestranteDto Palestrante { get; set; }
        public EventoDto Evento { get; set; }

     


    }
}