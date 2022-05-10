using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using CadastroEventos.Domain;
using CadastroEventos.Domain.Identity;

namespace CadastroEventos.Persistence.Contrato
{
    public interface IUserPersist
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByNameAsync(string username);

    }
}