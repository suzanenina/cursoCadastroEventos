using System.Collections.Generic;
using System.Threading.Tasks;
using CadastroEventos.Domain.Identity;
using CadastroEventos.Persistence.Contextos;
using CadastroEventos.Persistence.Contrato;
using Microsoft.EntityFrameworkCore;

namespace CadastroEventos.Persistence
{
    public class UserPersist : GeralPersist, IUserPersist
    {
        private readonly EventoContext _context;
        public UserPersist(EventoContext context) : base (context)
        {

            _context = context;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
       
        public async Task<User> GetUserByIdAsync(int id)
        {
           return await _context.Users.FindAsync(id);
        }

        public async Task<User> GetUserByNameAsync(string username)
        {
            return await _context.Users.SingleOrDefaultAsync(user => user.UserName == username); 
        }


        
    }
}