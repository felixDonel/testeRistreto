using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ristreto.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Ristreto.Data.Configurations
{
    public class EmpresaEntityTypeConfiguration : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.NomeEmpresarial)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Telefone)
                .HasMaxLength(20);

            builder.Property(e => e.URL)
                .HasMaxLength(255);

            builder.HasMany(e => e.Funcionarios)
                .WithOne(f => f.Empresa)
                .HasForeignKey(f => f.EmpresaId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
