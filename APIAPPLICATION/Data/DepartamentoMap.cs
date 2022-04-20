using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    internal class DepartamentoMap : IEntityTypeConfiguration<Departamento>
    {
        public void Configure(EntityTypeBuilder<Departamento> builder)
        {
            builder.ToTable("Departamento")
            .HasKey(e => e.IdDepartamento);

            builder.Property(m => m.Nombre)
            .HasMaxLength(50).IsUnicode(false);
        }
    }
}
