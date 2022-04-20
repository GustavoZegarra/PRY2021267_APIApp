using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    internal class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario")
            .HasKey(e => e.IdUsuario);

            builder.Property(m => m.Nombre)
           .HasMaxLength(250).IsUnicode(false);

            builder.Property(m => m.Correo)
           .HasMaxLength(250).IsUnicode(false);

            builder.Property(m => m.Token)
           .HasColumnType("varbinary(max)");

            builder.Property(m => m.Celular)
           .HasMaxLength(20).IsUnicode(false);

            builder.Property(m => m.FechaNacimiento)
          .HasColumnType("date");
        }
    }
}
