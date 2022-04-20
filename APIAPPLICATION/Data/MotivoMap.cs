using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    internal class MotivoMap : IEntityTypeConfiguration<Motivo>
    {
        public void Configure(EntityTypeBuilder<Motivo> builder)
        {
            builder.ToTable("Motivo")
            .HasKey(e => e.IdMotivo);

            builder.Property(m => m.Detalle)
           .HasMaxLength(250).IsUnicode(true);

            //Una Categoria tiene varios Motivos
            builder.HasOne(e => e.Categoria)
           .WithMany(e => e.Motivos)
           .HasForeignKey(e => e.IdCategoria)
           .HasConstraintName("FK_Motivo_Categoria");
        }
    }
}
