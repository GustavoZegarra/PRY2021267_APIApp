using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    internal class RecomendacionMap : IEntityTypeConfiguration<Recomendacion>
    {
        public void Configure(EntityTypeBuilder<Recomendacion> builder)
        {
            builder.ToTable("Recomendacion")
            .HasKey(e => e.IdRecomendacion);

            builder.Property(m => m.Detalle)
           .HasMaxLength(250).IsUnicode(true);

            //Un Nivel tiene varias Recomendaciones
            builder.HasOne(e => e.Nivel)
           .WithMany(e => e.Recomendaciones)
           .HasForeignKey(e => e.IdNivel)
           .HasConstraintName("FK_Recomendacion_Nivel");
        }
    }
}
