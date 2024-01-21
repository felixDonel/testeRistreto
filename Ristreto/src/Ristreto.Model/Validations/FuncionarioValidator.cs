using FluentValidation;
using Ristreto.Domain.Models;

namespace Ristreto.Domain.validations
{
    public class FuncionarioValidator : AbstractValidator<Funcionario>
    {
        public FuncionarioValidator()
        {
            RuleFor(f => f.Nome).NotEmpty().WithMessage("O campo Nome é obrigatório.");
            RuleFor(f => f.Email).NotEmpty().EmailAddress().WithMessage("Informe um endereço de email válido.");
            RuleFor(f => f.Cargo).NotEmpty().WithMessage("O campo Cargo é obrigatório.");
            RuleFor(f => f.DataNascimento).NotEmpty().WithMessage("O campo Data de Nascimento é obrigatório.");
            RuleFor(f => f.UserName).NotEmpty().WithMessage("O campo UserName é obrigatório.");
            RuleFor(f => f.PasswordHash).NotEmpty().WithMessage("O campo PasswordHash é obrigatório.");
        }
    }

}
