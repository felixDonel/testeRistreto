using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Ristreto.Data.Configurations;
using Ristreto.Domain.Models;
using System.Reflection.Emit;

namespace Ristreto.Data
{
    public class RistretoDbContext : DbContext
    {
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }

        public RistretoDbContext(DbContextOptions<RistretoDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmpresaEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new FuncionarioEntityTypeConfiguration());
        }
    }
}
