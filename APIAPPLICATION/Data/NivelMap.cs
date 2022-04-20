using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    internal class NivelMap : IEntityTypeConfiguration<Nivel>
    {
        public void Configure(EntityTypeBuilder<Nivel> builder)
        {
            builder.ToTable("Nivel")
            .HasKey(e => e.IdNivel);

            builder.Property(m => m.Riesgo)
              .HasMaxLength(50).IsUnicode(false);

            builder.Property(m => m.PrecipitacionLimSup).HasColumnType("float");
            builder.Property(m => m.PrecipitacionLimInf).HasColumnType("float");

        }
    }
}
