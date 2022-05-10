using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CadastroEventos.Domain.Identity;
using Microsoft.AspNetCore.Identity;

namespace CadastroEventos.Domain
{
    public class Palestrante 
    {
        [Key]
        public int PalestranteId { get; set; }
        public string Nome { get; set; }
        public string MiniCurriculo { get; set; }
        public string ImagemURL { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        public int Id { get; set; } //UserId apenas convenção
        public User User { get; set; }
        public IEnumerable<RedeSocial> RedesSociais { get; set; }
        public IEnumerable<PalestranteEvento> PalestrantesEventos { get; set; }

    }
}