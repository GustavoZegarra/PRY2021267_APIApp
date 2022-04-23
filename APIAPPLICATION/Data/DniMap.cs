using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    internal class DniMap : IEntityTypeConfiguration<DNI>
    {
        public void Configure(EntityTypeBuilder<DNI> builder)
        {
            builder.ToTable("DNI")
            .HasKey(e => e.IdDni);

            builder.Property(m => m.Dni)
            .HasMaxLength(8).IsUnicode(false);

            builder.Property(m => m.Direccion)
           .HasMaxLength(250).IsUnicode(true);

            builder.Property(m => m.Referencia)
           .HasMaxLength(250).IsUnicode(true);


            //Un Distrtio tiene varios DNIs
            builder.HasOne(e => e.Distrito)
           .WithMany(e => e.DNIs)
           .HasForeignKey(e => e.IdDistrito)
           .HasConstraintName("FK_DNI_Distrito");

            //Relacion 1 a 1 con DNI
            builder.HasOne(e => e.Usuario)
           .WithOne(e => e.DNI)
           .HasForeignKey<Usuario>(e => e.IdDni).OnDelete(DeleteBehavior.Cascade)
           .HasConstraintName("FK_Usuario_Dni");
        }
    }
}
