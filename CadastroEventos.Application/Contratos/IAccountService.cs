using System.Threading.Tasks;
using CadastroEventos.Application.Dtos;
using Microsoft.AspNetCore.Identity;

namespace ICadastroEventos.Application.Contratos
{
    public interface IAccountService
    {
        Task<bool> UserExists(string username);
        Task<UserUpdateDto> GetUserByUserNameAsync(string username);
        Task<SignInResult> GetUserByUserNameAsync(UserUpdateDto userUpdateDto, string password);
        Task<UserDto> CreateAccountAsync(UserDto userDto);
        Task<UserUpdateDto> UpdateAccount(UserUpdateDto userDto);

    }

}