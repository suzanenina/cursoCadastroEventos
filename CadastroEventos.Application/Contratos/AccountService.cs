using System;
using System.Threading.Tasks;
using AutoMapper;
using CadastroEventos.Application.Dtos;
using CadastroEventos.Domain;
using CadastroEventos.Domain.Identity;
using CadastroEventos.Persistence.Contrato;
using ICadastroEventos.Application.Contratos;
using Microsoft.AspNetCore.Identity;

namespace CadastroEventos.Application.Contratos
{
    public class AccountService : IAccountService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signManager;

        public AccountService(UserManager<User> userManager, SignInManager<User> signManager,
            IMapper mappper)
        {
            _signManager = signManager;
            _userManager = userManager;
            _mapper = mappper;
        }

        public async Task<UserDto> CreateAccountAsync(UserDto userDto)
        {
            try
            {

            }
            catch (System.Exception ex)
            {

                throw new Exception($"Erro ao tentar verificar password. Erro:{ex.Message}");
            }
        }

        public async Task<UserUpdateDto> GetUserByUserNameAsync(string username)
        {
            try
            {

            }
            catch (System.Exception ex)
            {

                throw new Exception($"Erro ao tentar verificar password. Erro:{ex.Message}");
            }
        }

        public async Task<SignInResult> GetUserByUserNameAsync(UserUpdateDto userUpdateDto, string password)
        {
            try
            {

            }
            catch (System.Exception ex)
            {

                throw new Exception($"Erro ao tentar verificar password. Erro:{ex.Message}");
            }
        }

        public async Task<UserUpdateDto> UpdateAccount(UserUpdateDto userDto)
        {
            try
            {

            }
            catch (System.Exception ex)
            {

                throw new Exception($"Erro ao tentar verificar password. Erro:{ex.Message}");
            }
        }

        public async Task<bool> UserExists(string username)
        {
            try
            {

            }
            catch (System.Exception ex)
            {

                throw new Exception($"Erro ao tentar verificar password. Erro:{ex.Message}");
            }
        }
    }
}