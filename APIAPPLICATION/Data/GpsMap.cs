using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    internal class GpsMap : IEntityTypeConfiguration<GPS>
    {
        public void Configure(EntityTypeBuilder<GPS> builder)
        {
            builder.ToTable("GPS")
            .HasKey(e => e.IdGps);

            builder.Property(m => m.Latitud).HasColumnType("float");
            builder.Property(m => m.Latitud).HasColumnType("float");


            //Relacion 1 a 1 GPS con Incidente
            builder.HasOne(e => e.Incidente)
           .WithOne(e => e.GPS)
           .HasForeignKey<Incidente>(e => e.IdGPS)
           .HasConstraintName("FK_Incidente_Gps");
        }
    }
}
