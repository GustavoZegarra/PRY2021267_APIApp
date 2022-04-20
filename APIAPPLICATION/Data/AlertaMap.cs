using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    internal class AlertaMap : IEntityTypeConfiguration<Alerta>
    {
        public void Configure(EntityTypeBuilder<Alerta> builder)
        {
            builder.ToTable("Alerta")
           .HasKey(e => e.IdAlerta);

            builder.Property(m => m.PrecipitacionProm).HasColumnType("float");
            builder.Property(m => m.PrecipitacionMax).HasColumnType("float");
            builder.Property(m => m.PrecipitacionMin).HasColumnType("float");

            builder.Property(m => m.Descripcion)
           .HasMaxLength(250).IsUnicode(false);

            builder.Property(m => m.FechaRegistro)
         .HasColumnType("date");

            //Una Nivel tiene varios Alertas
            builder.HasOne(e => e.Nivel)
           .WithMany(e => e.Alertas)
           .HasForeignKey(e => e.IdNivel)
           .HasConstraintName("FK_Alerta_Nivel");

            //Un Sensor tiene varias Alertas
            builder.HasOne(e => e.Sensor)
           .WithMany(e => e.Alertas)
           .HasForeignKey(e => e.IdSensor)
           .HasConstraintName("FK_Alerta_Sensor");
        }
    }
}
