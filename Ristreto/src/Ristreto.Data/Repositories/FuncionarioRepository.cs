using Microsoft.EntityFrameworkCore;
using Ristreto.Domain.Interfaces;
using Ristreto.Domain.Models;
using System;
using System.Runtime.InteropServices;

namespace Ristreto.Data.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly RistretoDbContext _context;

        public FuncionarioRepository(RistretoDbContext context)
        {
            _context = context;
        }

        public async Task<int> Add(Funcionario entity)
        {
            _context.Funcionarios.Add(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<Funcionario>> GetAll()
        {
            return await _context.Funcionarios.AsNoTracking().ToListAsync();
        }

        public async Task<Funcionario> GetById(string id)
        {
            return await _context.Funcionarios.FindAsync(id);
        }
        public async Task<bool> AnyUserName(string username)
        {
            return await _context.Funcionarios.AsNoTracking().AnyAsync(f => f.UserName == username);
        }

        public async Task<int> Update(Funcionario entity)
        {
            _context.Funcionarios.Update(entity);
            var retorno = await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
            return retorno;
        }
        public async Task<int> Delete(Funcionario entity)
        {
            _context.Funcionarios.Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Funcionario>> GetByEmpresaId(int empresaId)
        {
            return await _context.Funcionarios.Where(f => f.EmpresaId == empresaId)
                                              .AsNoTracking()
                                              .ToListAsync();
        }
    }
}
