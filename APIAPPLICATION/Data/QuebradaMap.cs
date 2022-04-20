using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    internal class QuebradaMap : IEntityTypeConfiguration<Quebrada>
    {
        public void Configure(EntityTypeBuilder<Quebrada> builder)
        {
            builder.ToTable("Quebrada")
            .HasKey(e => e.IdQuebrada);


            builder.Property(m => m.Nombre)
                    .HasMaxLength(50).IsUnicode(false);

            builder.Property(m => m.Descripcion)
                    .HasMaxLength(250).IsUnicode(false);
        }
    }
}
