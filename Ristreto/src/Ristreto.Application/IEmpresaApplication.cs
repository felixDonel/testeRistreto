using Ristreto.Application.DTO;
using Ristreto.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ristreto.Application
{
    public interface IEmpresaApplication
    {
        Task Add(EmpresaDTO empresa);
        Task Delete(int Id);
        Task<IEnumerable<EmpresaDTO>> GetAll();
        Task<EmpresaDTO> GetForId(int id);
        Task Update(EmpresaDTO empresa);
    }
}
