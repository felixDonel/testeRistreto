using Ristreto.Domain.Models;
using FluentValidation;

namespace Ristreto.Domain.validations
{
    public class EmpresaValidator : AbstractValidator<Empresa>
    {
        public EmpresaValidator()
        {
            RuleFor(e => e.NomeEmpresarial).NotEmpty().WithMessage("O campo Nome Empresarial é obrigatório.");
            RuleFor(e => e.Telefone).NotEmpty().Matches(@"^\(?\d{2}\)?\s?\d{8,9}$").WithMessage("Informe um DDD válido.");
            RuleFor(e => e.URL).NotEmpty().Matches(@"^(http(s)?://)?([\w-]+.)+[\w-]+(/[\w- ./?%&=])?$").WithMessage("Informe uma URL válida.");
        }
    }

}
