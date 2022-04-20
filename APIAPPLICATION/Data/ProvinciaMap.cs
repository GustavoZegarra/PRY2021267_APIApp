using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    internal class ProvinciaMap : IEntityTypeConfiguration<Provincia>
    {
        public void Configure(EntityTypeBuilder<Provincia> builder)
        {
            builder.ToTable("Provincia")
           .HasKey(e => e.IdProvincia);

            builder.Property(m => m.Nombre)
            .HasMaxLength(50).IsUnicode(false);

            //Un departamento tiene varias provincias
            builder.HasOne(e => e.Departamento)
           .WithMany(e => e.Provincias)
           .HasForeignKey(e => e.IdDepartamento)
           .HasConstraintName("FK_Provincia_Departamento");
        }
    }
}
