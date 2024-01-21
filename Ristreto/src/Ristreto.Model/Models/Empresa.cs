using FluentValidation;
using Ristreto.Domain.validations;

namespace Ristreto.Domain.Models
{
    public class Empresa
    {
        public int Id { get; private set; }
        public string NomeEmpresarial { get; private set; }
        public string Telefone { get; private set; }
        public string URL { get; private set; }

        public virtual ICollection<Funcionario> Funcionarios { get; set; }
        public Empresa()
        {
            
        }
        public Empresa(string nomeEmpresarial, string telefone, string url)
        {
            NomeEmpresarial = nomeEmpresarial;
            Telefone = telefone;
            URL = url;
        }
        public Empresa(int id, string nomeEmpresarial, string telefone, string url)
        {
            Id = id;
            NomeEmpresarial = nomeEmpresarial;
            Telefone = telefone;
            URL = url;
        }
    }

}
