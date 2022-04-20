using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    internal class PaisMap : IEntityTypeConfiguration<Pais>
    {
        public void Configure(EntityTypeBuilder<Pais> builder)
        {
            builder.ToTable("Pais")
            .HasKey(e => e.IdPais);

            builder.Property(m => m.Nombre)
           .HasMaxLength(50).IsUnicode(false);

            builder.Property(m => m.Codigo)
           .HasMaxLength(3).IsUnicode(false);

            builder.Property(m => m.Gentilicio)
           .HasMaxLength(50).IsUnicode(false);


            //Un Continente tiene varios Paises
            builder.HasOne(e => e.Continente)
           .WithMany(e => e.Paises)
           .HasForeignKey(e => e.IdContinente)
           .HasConstraintName("FK_Pais_Continente");
        }
    }
}
