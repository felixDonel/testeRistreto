using Ristreto.Domain.Enum;
using Ristreto.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ristreto.Application.DTO
{
    public class FuncionarioDTO
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public string Email{ get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; } 
        public DateTime DataNascimento { get; set; }
        public ESituacaoFuncionario Situacao { get; set; }
        public int EmpresaId { get; set; }
    }

    public static class FuncionarioDTOFactory
    {
        public static Funcionario CreateEntity(FuncionarioDTO createDTO)
        {
            return new Funcionario(
                createDTO.Nome,
                createDTO.Email,
                createDTO.Cargo,
                createDTO.DataNascimento,
                createDTO.UserName,
                createDTO.PasswordHash,
                createDTO.Situacao,
                createDTO.EmpresaId
            );
        }
        public static FuncionarioDTO CreateDTO(Funcionario funcionario)
        {
            return new FuncionarioDTO
            {
                Id = funcionario.Id,
                Nome = funcionario.Nome,
                Email = funcionario.Email,
                Cargo = funcionario.Cargo,
                UserName = funcionario.UserName,
                PasswordHash = funcionario.PasswordHash,
                DataNascimento = funcionario.DataNascimento,
                Situacao = funcionario.Situacao,
                EmpresaId = funcionario.EmpresaId
            };
        }
    }
}
