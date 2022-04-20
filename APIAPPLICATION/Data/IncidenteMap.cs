using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    internal class IncidenteMap : IEntityTypeConfiguration<Incidente>
    {
        public void Configure(EntityTypeBuilder<Incidente> builder)
        {
            builder.ToTable("Incidente")
            .HasKey(e => e.IdIncidente);

            builder.Property(m => m.Descripcion)
           .HasMaxLength(250).IsUnicode(true);

            builder.Property(e => e.Imagen)
            .HasColumnType("varbinary(max)");

            builder.Property(m => m.FechaRegistro)
           .HasColumnType("date");

            builder.Property(m => m.FechaActualizacion)
          .HasColumnType("date");

            builder.Property(e => e.Resuelto)
             .HasColumnType("bit");

            //Un Usuario tiene varios Incidentes
            builder.HasOne(e => e.Usuario)
           .WithMany(e => e.Incidentes)
           .HasForeignKey(e => e.IdUsuario)
           .HasConstraintName("FK_Incidente_Usuario");


            //Una quebrada puede ser reportada en varios incidentes
            builder.HasOne(e => e.Quebrada)
           .WithMany(e => e.Incidentes)
           .HasForeignKey(e => e.IdQuebrada)
           .HasConstraintName("FK_Incidente_Quebrada");


            //Un Motivo Puede estar en varios Incidentes
            builder.HasOne(e => e.Motivo)
           .WithMany(e => e.Incidentes)
           .HasForeignKey(e => e.IdMotivo)
           .HasConstraintName("FK_Incidente_Motivo");

        }
    }
}
