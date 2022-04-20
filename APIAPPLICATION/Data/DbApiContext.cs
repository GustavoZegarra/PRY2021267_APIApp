using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class DbApiContext : DbContext
    {


        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<Distrito> Distritos { get; set; }
        public DbSet<Continente> Continentes { get; set; }
        public DbSet<Pais> Pais { get; set; }
        public DbSet<Pasaporte> Pasaportes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<DNI> DNIs { get; set; }
        public DbSet<Incidente> Incidentes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Motivo> Motivos { get; set; }
        public DbSet<GPS> GPSes { get; set; }
        public DbSet<Quebrada> Quebradas { get; set; }
        public DbSet<Sensor> Sensores { get; set; }
        public DbSet<Wifi> Wifis { get; set; }
        public DbSet<Alerta> Alertas { get; set; }
        public DbSet<Nivel> Niveles { get; set; }
        public DbSet<Recomendacion> Recomendaciones { get; set; }

        //para que DbApiContext funcione
        public DbApiContext(DbContextOptions<DbApiContext>options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new DepartamentoMap());
            modelBuilder.ApplyConfiguration(new ProvinciaMap());
            modelBuilder.ApplyConfiguration(new DistritoMap());
            modelBuilder.ApplyConfiguration(new ContinenteMap());
            modelBuilder.ApplyConfiguration(new PaisMap());
            modelBuilder.ApplyConfiguration(new PasaporteMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new DniMap());
            modelBuilder.ApplyConfiguration(new IncidenteMap());
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new MotivoMap());
            modelBuilder.ApplyConfiguration(new GpsMap());
            modelBuilder.ApplyConfiguration(new QuebradaMap());
            modelBuilder.ApplyConfiguration(new SensorMap());
            modelBuilder.ApplyConfiguration(new WifiMap());
            modelBuilder.ApplyConfiguration(new AlertaMap());
            modelBuilder.ApplyConfiguration(new NivelMap());
            modelBuilder.ApplyConfiguration(new RecomendacionMap());

        }


    }
}
