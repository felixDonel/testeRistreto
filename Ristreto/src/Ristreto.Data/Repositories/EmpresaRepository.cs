using Microsoft.EntityFrameworkCore;
using Ristreto.Domain.Interfaces;
using Ristreto.Domain.Models;

namespace Ristreto.Data.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly RistretoDbContext _context;

        public EmpresaRepository(RistretoDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(Empresa entity)
        {
            _context.Empresas.Add(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<Empresa>> GetAll()
        {
            return await _context.Empresas.AsNoTracking().ToListAsync();
        }

        public async Task<Empresa> GetById(int id)
        {
            return await _context.Empresas.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<int> Update(Empresa entity)
        {
            _context.Empresas.Update(entity);
            var retorno = await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
            return retorno;
        }
        public async Task<int> Delete(Empresa entity)
        {
            _context.Empresas.Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> EmpresaIsRegistered(int id)
        {
            return await _context.Empresas.AsNoTracking().AnyAsync(p => p.Id == id);
        }
    }
}
