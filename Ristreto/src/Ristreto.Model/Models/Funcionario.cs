using Ristreto.Domain.Enum;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Ristreto.Domain.validations;
using FluentValidation;

namespace Ristreto.Domain.Models
{
    public class Funcionario : IdentityUser
    {
        public string Nome { get; private set; }
        public string Cargo { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public ESituacaoFuncionario Situacao { get; private set; }
        public int EmpresaId { get; private set; }
        public virtual Empresa Empresa { get; private set; }

        public Funcionario(){ }

        public Funcionario(string nome, string email, string cargo, DateTime dataNascimento, string userName, string passwordHash, ESituacaoFuncionario situacao, int empresaid)
        {
            Nome = nome;
            Email = email;
            Cargo = cargo;
            DataNascimento = dataNascimento;
            UserName = userName;
            PasswordHash = passwordHash;
            Situacao = situacao;
            EmpresaId = empresaid; 
        }



    }

}
