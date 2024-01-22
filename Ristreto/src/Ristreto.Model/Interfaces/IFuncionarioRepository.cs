using Ristreto.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ristreto.Domain.Interfaces
{
    public interface IFuncionarioRepository : IRepository<Funcionario>
    {
        Task<Funcionario> GetById(string id);
        Task<IEnumerable<Funcionario>> GetByEmpresaId(int empresaId);
        Task<bool> AnyUserName(string username);
    }
}
