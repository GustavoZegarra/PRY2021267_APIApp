using System;

namespace Entities
{
    public class Alerta
    {
        public int IdAlerta { get; set; }
        public float? PrecipitacionProm { get; set; }
        public float? PrecipitacionMax { get; set; }
        public float? PrecipitacionMin { get; set; }
        public string Descripcion { get; set; } 
        public DateTime? FechaRegistro { get; set; }

        //fk
        public int? IdNivel { get; set; }
        public Nivel Nivel { get; set; }

        //fk 
        public int? IdSensor {get; set; }
        public Sensor Sensor { get; set; }



    }
}
