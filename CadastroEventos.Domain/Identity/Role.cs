using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace CadastroEventos.Domain.Identity
{
    public class Role : IdentityRole<int>
    {
        public IEnumerable<UserRole> UserRoles { get; set; }   
    }
}