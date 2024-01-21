using Ristreto.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ristreto.Application.DTO
{
    public class EmpresaDTO
    {
        public int Id { get; set; }
        public string NomeEmpresarial { get; set; }
        public string Telefone { get; set; }
        public string URL { get; set; }
    }

    public static class EmpresaDTOFactory
    {
        public static EmpresaDTO CreateDTO(Empresa empresa)
        {
            return new EmpresaDTO
            {
                Id = empresa.Id,
                NomeEmpresarial = empresa.NomeEmpresarial,
                Telefone = empresa.Telefone,
                URL = empresa.URL
            };
        }
        public static Empresa Create(EmpresaDTO empresa)
        {
            return new Empresa(
                empresa.Id,
                empresa.NomeEmpresarial,
                empresa.Telefone,
                empresa.URL);
        }

    }
}
