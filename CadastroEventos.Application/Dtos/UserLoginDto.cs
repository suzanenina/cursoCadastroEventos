using System.ComponentModel.DataAnnotations;

namespace CadastroEventos.Application.Dtos
{
    public class UserLoginDto 
    {
        public string  Username { get; set; }
        public string  Password { get; set; }
    }
}