using Ristreto.Application.DTO;
using Ristreto.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ristreto.Application
{
    public interface IFuncionarioApplication
    {
        Task Add(FuncionarioDTO funcionario);
        Task Delete(string Id);
        Task<IEnumerable<FuncionarioDTO>> GetForEmpresaId(int id);
        Task<FuncionarioDTO> GetForId(string id);
        Task Update(FuncionarioDTO funcionario);
    }
}
