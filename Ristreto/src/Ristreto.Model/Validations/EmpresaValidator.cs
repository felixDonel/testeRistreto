using Ristreto.Domain.Models;
using FluentValidation;

namespace Ristreto.Domain.validations
{
    public class EmpresaValidator : AbstractValidator<Empresa>
    {
        public EmpresaValidator()
        {
            RuleFor(e => e.NomeEmpresarial).NotEmpty()
                                           .WithMessage("O campo Nome Empresarial é obrigatório.");

            RuleFor(e => e.Telefone).NotEmpty()
                                    .WithMessage("O campo Telefone é obrigatório.")
                                    .Matches(@"^\(?\d{0,2}\)?\s?\d{8,9}$")
                                    .WithMessage("Informe um número de telefone com DDD válido.");

            RuleFor(e => e.URL).NotEmpty().WithMessage("O campo URL é obrigatório.")
                               .Matches(@"^(http(s)?://)?(www\.)[a-zA-Z0-9-]+(\.[a-zA-Z]{2,})+(/[a-zA-Z0-9- ./?%&=]*)?$")
                               .WithMessage("Informe uma URL válida começando com 'www.' e uma extensão de domínio válida.");
        }
    }

}
