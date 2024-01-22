using Ristreto.Data.Repositories;
using Ristreto.Domain.Interfaces;
using Ristreto.Domain.Models;
using Ristreto.Domain.validations;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ristreto.Application.DTO;

namespace Ristreto.Application
{
    public class FuncionarioApplication : IFuncionarioApplication
    {
        private readonly IFuncionarioRepository _funcionarioRepository;
        public FuncionarioApplication(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }
        public async Task Add(FuncionarioDTO funcionarioDTO)
        {
            try
            {
                Funcionario funcionario = FuncionarioDTOFactory.CreateEntity(funcionarioDTO);

                FuncionarioValidator validator = new FuncionarioValidator();
                validator.ValidateAndThrow(funcionario);

                if (await _funcionarioRepository.AnyUserName(funcionario.UserName))
                    throw new ValidationException("Username já cadastrado!");

                await _funcionarioRepository.Add(funcionario);
            }
            catch (ValidationException ex)
            {
                throw;
            }
            catch (Exception)
            {
                // entender o porque esta dando erro na DI do DBcontext depois de salvo no banco
            }

        }

        public async Task Delete(string funcionarioId)
        {
            try
            {

                Funcionario funcionario = await _funcionarioRepository.GetById(funcionarioId);
                await _funcionarioRepository.Delete(funcionario);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<FuncionarioDTO>> GetForEmpresaId(int id)
        {
            return (await _funcionarioRepository.GetAll()).Select(f => FuncionarioDTOFactory.CreateDTO(f));
        }

        public async Task<FuncionarioDTO> GetForId(string id)
        {
            return FuncionarioDTOFactory.CreateDTO(await _funcionarioRepository.GetById(id)) ;
        }


        public async Task Update(FuncionarioDTO funcionarioDTO)
        {
            Funcionario funcionario = FuncionarioDTOFactory.CreateEntity(funcionarioDTO);
            FuncionarioValidator validator = new FuncionarioValidator();
            validator.ValidateAndThrow(funcionario);

            await _funcionarioRepository.Update(funcionario);
        }
    }
}
