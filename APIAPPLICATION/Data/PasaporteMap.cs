using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    internal class PasaporteMap : IEntityTypeConfiguration<Pasaporte>
    {
        public void Configure(EntityTypeBuilder<Pasaporte> builder)
        {
            builder.ToTable("Pasaporte")
            .HasKey(e => e.IdPasaporte);

            builder.Property(m => m.Numero)
           .HasMaxLength(50).IsUnicode(false);

            //Un Pais tiene varios Pasaportes
            builder.HasOne(e => e.Pais)
           .WithMany(e => e.Pasaportes)
           .HasForeignKey(e => e.IdPais)
           .HasConstraintName("FK_Pasaporte_Pais");

            //Relacion 1 a 1 con Pasaporte
            builder.HasOne(e => e.Usuario)
           .WithOne(e => e.Pasaporte)
           .HasForeignKey<Usuario>(e => e.IdPasaporte).OnDelete(DeleteBehavior.Cascade)
           .HasConstraintName("FK_Usuario_Pasaporte");
        }
    }
}
