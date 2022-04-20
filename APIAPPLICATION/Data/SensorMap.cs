using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    internal class SensorMap : IEntityTypeConfiguration<Sensor>
    {
        public void Configure(EntityTypeBuilder<Sensor> builder)
        {
            builder.ToTable("Sensor")
            .HasKey(e => e.IdSensor);

            builder.Property(m => m.Modelo)
              .HasMaxLength(50).IsUnicode(false);


            builder.Property(m => m.PrecipitacionMax).HasColumnType("float");
            builder.Property(m => m.PrecipitacionMin).HasColumnType("float");


            //Una quebrada tiene varios Sensores
            builder.HasOne(e => e.Quebrada)
           .WithMany(e => e.Sensores)
           .HasForeignKey(e => e.IdQuebrada)
           .HasConstraintName("FK_Sensor_Quebrada");
        }
    }
}
