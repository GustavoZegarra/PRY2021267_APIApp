using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    internal class DistritoMap : IEntityTypeConfiguration<Distrito>
    {
        public void Configure(EntityTypeBuilder<Distrito> builder)
        {
            builder.ToTable("Distrito")
            .HasKey(e => e.IdDistrito);

            builder.Property(m => m.Nombre)
            .HasMaxLength(50).IsUnicode(false);

            //Una Provincia tiene varios distritos
            builder.HasOne(e => e.Provincia)
           .WithMany(e => e.Distritos)
           .HasForeignKey(e => e.IdProvincia)
           .HasConstraintName("FK_Distrito_Provincia");
        }
    }
}
