using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    internal class ContinenteMap : IEntityTypeConfiguration<Continente>
    {
        public void Configure(EntityTypeBuilder<Continente> builder)
        {
            builder.ToTable("Continente")
            .HasKey(e => e.IdContinente);

            builder.Property(m => m.Nombre)
           .HasMaxLength(50).IsUnicode(false);

            builder.Property(m => m.Codigo)
           .HasMaxLength(2).IsUnicode(false);
        }
    }
}
