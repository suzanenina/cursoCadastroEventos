using System.Collections.Generic;
using CadastroEventos.Domain.Enum;
using Microsoft.AspNetCore.Identity;

namespace CadastroEventos.Domain.Identity
{
    public class User : IdentityUser<int>
    {
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public Titulo titulo { get; set; }
        public string Descricao { get; set; }

        public Funcao Funcao { get; set; }
        public string ImagemUrl { get; set; }
        public IEnumerable<UserRole> UserRoles { get; set; }

    }
}