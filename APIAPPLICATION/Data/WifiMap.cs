using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    internal class WifiMap : IEntityTypeConfiguration<Wifi>
    {
        public void Configure(EntityTypeBuilder<Wifi> builder)
        {
            builder.ToTable("Wifi")
            .HasKey(e => e.IdWifi);

            builder.Property(m => m.Modelo)
            .HasMaxLength(50).IsUnicode(false);

            builder.Property(m => m.Standar)
            .HasMaxLength(50).IsUnicode(false);

            builder.Property(m => m.Protocolo)
            .HasMaxLength(50).IsUnicode(false);

            builder.Property(m => m.Red)
            .HasMaxLength(50).IsUnicode(false);

            //Relacion 1 a 1 Wifi con Sensor
            builder.HasOne(e => e.Sensor)
           .WithOne(e => e.Wifi)
           .HasForeignKey<Sensor>(e => e.IdWifi)
           .HasConstraintName("FK_Sensor_Wifi");
        }
    }
}
